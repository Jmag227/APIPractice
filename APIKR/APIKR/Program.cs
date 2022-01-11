using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace APIKR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                QuoteGenerator.KanyeQuote();
                Console.WriteLine();
                QuoteGenerator.SwansonQuote();
                Console.WriteLine();
            }
        }
            
    }
    public class QuoteGenerator
    {
        public static void KanyeQuote()
        {
            var client = new HttpClient();

            var kanyeURL = " https://api.kanye.rest";

            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

            Console.WriteLine($"Kanye: '{kanyeQuote}'");
        }

        public static void SwansonQuote()
        {
            var client = new HttpClient();

            var swanURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            var swanResponse = client.GetStringAsync(swanURL).Result;

            var swanQuote = JArray.Parse(swanResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

            Console.WriteLine($"Ron: {swanQuote}");
        }

    }
}
