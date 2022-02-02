using EarPhonePriceCheck.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarPhonePriceCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            string amazonPath = "https://www.amazon.pl/Sony-WH-1000XM4-bezprzewodowe-sluchawki-sterowanie/dp/B08C7KG5LP/ref=sr_1_2?__mk_pl_PL=%C3%85M%C3%85%C5%BD%C3%95%C3%91&crid=3BSBCWRUKHUBZ&keywords=Sony+WH-1000XM4&qid=1643803598&sprefix=sony+wh-1000xm4%2Caps%2C83&sr=8-2";
            string directoryPath = @"C:\EarpodsPriceCheck";
            string filePath = directoryPath + @"\Prices.txt";

            Console.Title = "Sprawdzanie ceny słuchawek";
            Console.ForegroundColor = ConsoleColor.Green;

            Files.FolderAndFile(directoryPath, filePath);
            int currentPrice = Selenium.GetPrice(amazonPath);
            if (currentPrice == 0)
            {
                Console.WriteLine("Błąd!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            int lowestPrice = Prices.GetTheLowest(filePath);
            Prices.Compare(currentPrice, lowestPrice, filePath);
        }
    }
}
