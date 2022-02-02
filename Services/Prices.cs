using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarPhonePriceCheck.Services
{
    class Prices
    {
        public static int GetTheLowest(string filePath)
        {
            string fileContent = Files.GetFileContent(filePath);
            string[] prices = fileContent.Split(';');
            int[] pricesInt = new int[prices.Length - 1];
            int lowestPrice = 0;

            for (int i = 0; i < prices.Length - 1; i++)
            {
                pricesInt[i] = Convert.ToInt32(prices[i]);
            }

            lowestPrice = pricesInt.OrderBy(n => n).Min();

            return lowestPrice;
        }

        public static void Compare(int currentPrice, int lowestPrice, string filePath)
        {
            Files.AddCurrentPrice(currentPrice, filePath);
            
            if (currentPrice < lowestPrice)
            {
                EmailService.Send(currentPrice, lowestPrice);
            }
        }
    }
}
