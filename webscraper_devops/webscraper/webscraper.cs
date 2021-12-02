using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace webscraper
{
    public class Webscraper
    {
        public static void Main(string[] args)
        {
                // Use the chromedriver.exe in the Drivers folder.
            ChromeDriver driver = new ChromeDriver(@"../../" + "/Drivers/");
            driver.Manage().Window.Maximize();
                // set the timeout value to 10 seconds (will wait until items are loaded for a max of 10 seconds).
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                // Go to the website (YouTube in this case)
            driver.Navigate().GoToUrl("https://www.youtube.com/");
                // Click "accept Terms" button.
            driver.FindElement(By.XPath("//*[@id='content']/div[2]/div[5]/div[2]/ytd-button-renderer[2]")).Click();

            Console.WriteLine("helloz?");
                // sleep/wait for 1 second to let the items/page load, or else the input field is not fillable.
            System.Threading.Thread.Sleep(1000);
                // Find the Youtube input field.
            IWebElement searchBarInput = driver.FindElement(By.Name("search_query"));
                // Enter value in the field and submit it.
            searchBarInput.SendKeys("rick roll");
            searchBarInput.Submit();   
        }
    }
}
