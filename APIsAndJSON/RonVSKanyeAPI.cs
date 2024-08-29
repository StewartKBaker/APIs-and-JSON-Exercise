using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal class RonVSKanyeAPI
    {
        public static void Convo()
        {
            var client = new HttpClient();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Kanye says:\n{GetKanyeQuote(client)}\n");
                Thread.Sleep(2000);
                Console.WriteLine($"Ron says:\n{GetRonQuote(client)}\n");
                Thread.Sleep(2000);
            }
        }
        
        private static string GetKanyeQuote(HttpClient client)
        {
            var jsonText = client.GetStringAsync("https://api.kanye.rest/").Result;

            return JObject.Parse(jsonText).GetValue("quote").ToString();
        }

        private static string GetRonQuote(HttpClient client)
        {
            var jsonText = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;

            return jsonText.Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();
        }
    }
}
