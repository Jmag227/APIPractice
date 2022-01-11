using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OpenWeather
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine("Please enter your API Key:");
            var api_Key = Console.ReadLine();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter city name: ");
                var cityName = Console.ReadLine();
                var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=imperial&appid={api_Key}";

                var response = client.GetStringAsync(weatherURL).Result;
                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(formattedResponse);
                Console.WriteLine();
                Console.WriteLine("Would you like to choose anohter city?");
                var userinput = Console.ReadLine();
                Console.WriteLine();

                if (userinput.ToLower() == "no")
                {
                    break;
                }
            }
            
        }
    }
}
