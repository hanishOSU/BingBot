using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace BingBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new EdgeOptions();
            options.UseChromium = true;
            options.BinaryLocation = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";

            var driver = new EdgeDriver(options);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("https://www.bing.com/");
            driver.FindElement(By.Name("q")).SendKeys("cheese" + Keys.Enter);

            wait.Until(webDriver => webDriver.FindElement(By.CssSelector("h2")).Displayed);
            IWebElement firstResult = driver.FindElement(By.CssSelector("h2"));
            Console.WriteLine(firstResult.GetAttribute("textContent"));
        }
    }
}
