using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarPhonePriceCheck.Services
{
    class EmailService
    {
        public static void Send(int currentPrice, int lowestPrice)
        {
            Console.Clear();
            Console.WriteLine("Obecna cena słuchawek SONY WH-1000XM4: \n{0}zł.\nA najniższa zarejestrowana wcześniej:\n{1}zł", currentPrice, lowestPrice);
            Console.ReadKey();
        }
    }
}
