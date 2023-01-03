using Newtonsoft.Json;
using RestSharp;
using System;
using System.Globalization;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

internal class Program
{
    static HttpClient client = new HttpClient();
    private static async Task Main(string[] args)
    {
        var botClient = new TelegramBotClient("5881976282:AAFoObR4oz-lJqroNwSd5P_kWlz5sLmrPIo");

        using CancellationTokenSource cts = new();

        ReceiverOptions receiverOptions = new();
        {
            UpdateType[] AllowedUpdates = Array.Empty<UpdateType>();
        };
        botClient.StartReceiving(updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cts.Token
        );




        //var me = await botClient.GetMeAsync();
        //Console.WriteLine($"start listening for {me.Username}");
        Console.ReadLine();
        cts.Cancel();
        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { } message)
            {
                return;
            }
            if (message.Text is not { } messageText)
            {
                return;
            }


           
                      



            var chatId = message.Chat.Id;
            var userName = message.Chat.Username;

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId} from {userName}.");

            string ans = "";
            string data1 = messageText.ToLower();
            bool validInput = true;
            try
            {
                var client = new RestClient($"https://api.coingecko.com/api/v3/coins/{data1}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                dynamic data = JsonConvert.DeserializeObject(response.Content);
                string name = data.name;
                ans = data.market_data.current_price["usd"].ToString();
            }
            catch(Exception ex)
            {
                validInput = false;
                Console.WriteLine(ex.Message);
                
            }

            //  Console.WriteLine($"{name} has a current price of.${ans}");


            if (validInput)
            {
                Message sentMessage = await botClient.SendTextMessageAsync(
              chatId: chatId, text: messageText + " Current Price is $ " + ans,
              cancellationToken: cancellationToken
              );
            }
            else
            {
                Message sentMessage1 = await botClient.SendTextMessageAsync(
               chatId: chatId, text: "Check Coin Spelling",
               cancellationToken: cancellationToken
               );
            }
          

        }
        Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

    }
}