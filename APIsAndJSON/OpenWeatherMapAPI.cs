using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal class OpenWeatherMapAPI
    {
        public static void GetTemp()
        {
            //appsettings file text
            var appsettingsText = File.ReadAllText("appsettings.json");

            //turn json into an object to grap api key
            var apiKey = JObject.Parse(appsettingsText).GetValue("key").ToString();
            
            //ask user for zip, enter zip to provide for url, build url
            Console.WriteLine("Enter ZIP:");
            var zip = Console.ReadLine();
            var url = $"https://api.openweathermap.org/data/2.5/weather?zip={zip}&appid={apiKey}&units=imperial";

            //create http client 
            var client = new HttpClient();
            var jsonText = client.GetStringAsync(url).Result;

            var weatherObj = JObject.Parse(jsonText);
            
            Console.WriteLine($"Temp: {weatherObj["main"]["temp"]}");
            Console.WriteLine($"Feels Like: {weatherObj["main"]["feels_like"]}");
            Console.WriteLine($"Min Temp: {weatherObj["main"]["temp_min"]}");
            Console.WriteLine($"Max Temp: {weatherObj["main"]["temp_max"]}");
            Console.WriteLine($"Humidity: {weatherObj["main"]["humidity"]}");
        }
    }
}
