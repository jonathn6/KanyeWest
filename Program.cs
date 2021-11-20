using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace KanyeWest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("KanyeWest!");

            var clientKanye = new HttpClient();
            var clientRon = new HttpClient();
            var kanyeURL = "https://api.kanye.rest";
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            var kanyeResponse = "";
            var ronResponse = "";

            var kanyeQuote = "";
            var ronQuote = "";

            int loopCounter = 0;

            do
            {
                kanyeResponse = clientKanye.GetStringAsync(kanyeURL).Result;
                ronResponse = clientRon.GetStringAsync(ronURL).Result;

                kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                Console.WriteLine($"Kanye: {kanyeQuote}");
                Console.WriteLine($"Ron: {ronQuote}");
                Console.WriteLine("");
                loopCounter++;

            } while (loopCounter < 5);

        }
    }
}
