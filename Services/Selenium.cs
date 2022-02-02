
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarPhonePriceCheck
{
    class Selenium
    {
        public static int GetPrice(string amazonPath)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("headless");
            var driver = new ChromeDriver(chromeOptions);
            driver.Navigate().GoToUrl(amazonPath);
            Console.WriteLine(driver.Title);
            string amazonPrice = driver.FindElement(By.ClassName("a-price-whole")).Text;

            amazonPrice = amazonPrice.Replace(" ", "");
            int priceInt;

            try
            {
                priceInt = Convert.ToInt32(amazonPrice);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd. Powód: {0}", ex);
                driver.Close();
                driver.Dispose();
                return 0;
            }
            driver.Close();
            driver.Dispose();
            return priceInt;
        }
    }
}
