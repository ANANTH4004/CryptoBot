//using System;
//using RestSharp;
//using Newtonsoft.Json;

//namespace CoinGeckoApp
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Send a GET request to the CoinGecko API
//            var client = new RestClient("https://api.coingecko.com/api/v3/coins/bitcoin");
//            var request = new RestRequest(Method.GET);
//            IRestResponse response = client.Execute(request);

//            // Parse the JSON response
//            dynamic data = JsonConvert.DeserializeObject(response.Content);

//            // Extract the desired information from the response
//            Console.WriteLine(data);
//            string name = data.name;
//            var ans = data.market_data.current_price["usd"];
//           // decimal marketCap = data.market_cap.usd;

//            // Display the information to the console
//            Console.WriteLine($"{name} has a market cap of.{ans}");
//        }
//    }
//}
