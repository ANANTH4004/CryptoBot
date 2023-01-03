
//using System;
//using Telegram.Bot;
//using Telegram.Bot.Args;
//using Telegram.Bot.Polling;
//using Telegram.Bot.Types;
//using Telegram.Bot.Types.Enums;
//using Telegram.Bots.Types;
//using Update = Telegram.Bot.Types.Update;
//using UpdateType = Telegram.Bot.Types.Enums.UpdateType;

//namespace CryptoBot
//{
//    class Program
//    {
//        static TelegramBotClient bot = new TelegramBotClient("5881976282:AAFoObR4oz-lJqroNwSd5P_kWlz5sLmrPIo");
//        static void Main(string[] args)
//        {
//            Console.WriteLine("anand");
//            var receiverOptions = new ReceiverOptions
//            {
//                AllowedUpdates = new UpdateType[]
//                {
//                        UpdateType.Message,
//                        UpdateType.EditedMessage
//                }
//            };
//            bot.StartReceiving(UpdateHandler, ErrorHandler, receiverOptions);
//            Console.ReadLine();
//        }

//        private static Task ErrorHandler(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
//        {
//            throw new NotImplementedException();
//        }

//        private static async Task UpdateHandler(ITelegramBotClient _bot, Update update, CancellationToken caltok)
//        {
//            if (update.Type == UpdateType.Message)
//            {
//                if (update.Message.Type == MessageType.Text)
//                {
//                    string text = update.Message.Text;
//                    var id = update.Message.Chat.Id;
//                    string? userName = update.Message.Chat.Username;

//                    Console.WriteLine($"{text} | {id} | {userName}");
//                }
//            }
//        }
//    }



//}

//}

