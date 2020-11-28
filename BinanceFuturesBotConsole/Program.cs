using BinanceBotLib;
using System;

namespace BinanceFuturesBotConsole
{
    class Program
    {

        private static Bot myBot = new Bot();

        static void Main(string[] args)
        {
            Console.WriteLine("Initiating Binance Futures Bot!");

            // Error handling
            if (string.IsNullOrEmpty(myBot.Settings.APIKey))
            {
                Console.Write("Enter Binance API Key: ");
                myBot.Settings.APIKey = Console.ReadLine();

                Console.Write("Enter Binance Secret Key: ");
                myBot.Settings.SecretKey = Console.ReadLine();
            }

            // Set bot mode to Futures
            myBot.Settings.BotMode = BotMode.FuturesRandom;

            myBot.Start();

            Console.ReadLine();

        }
    }
}
