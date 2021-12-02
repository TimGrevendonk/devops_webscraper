using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace webscraper
{
    public class Webscraper
    {
        public static void Main(string[] args)
        {
                // Use the chromedriver.exe in the Drivers folder.
            ChromeDriver Driver = new ChromeDriver(@"../../" + "/Drivers/");
            Driver.Manage().Window.Maximize();
                // set the timeout value to 10 seconds (will wait until items are loaded for a max of 10 seconds).
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                // Go to the website (YouTube in this case)
            Driver.Navigate().GoToUrl("https://www.youtube.com/");
                // Click "accept Terms" button.
            Driver.FindElement(By.XPath("//*[@id='content']/div[2]/div[5]/div[2]/ytd-button-renderer[2]")).Click();

            Console.WriteLine("helloz?");
                // sleep/wait for 1 second to let the items/page load, or else the input field is not fillable.
            System.Threading.Thread.Sleep(1200);
                // Find the Youtube input field.
            IWebElement SearchBarInput = Driver.FindElement(By.Name("search_query"));
                // Enter value in the field and submit it.
            SearchBarInput.SendKeys("rick roll");
            SearchBarInput.Submit();
                // Wait for the page to load.
            System.Threading.Thread.Sleep(1000);
                // Find the filters button and click it
            IWebElement FilterButton = Driver.FindElement(By.XPath("//*[@id='container']/ytd-toggle-button-renderer/a"));
            FilterButton.Click();
            System.Threading.Thread.Sleep(700);
            // Find the "sort by: upload date" button and click it.
            IWebElement UploadDateButton = Driver.FindElement(By.XPath("//*[@id='collapse-content']/ytd-search-filter-group-renderer[5]/ytd-search-filter-renderer[2]/a"));
            UploadDateButton.Click();
            System.Threading.Thread.Sleep(1000);

            IList<IWebElement> videos = Driver.FindElements(By.Id("dismissible"));
            Console.WriteLine("Check starting...");
            foreach (IWebElement video in videos)
            {
                Console.WriteLine("- - - - -");
                //////////// unable to cast object, fix this !!!!
                //////////// TODO: trying to get all videos listed in a list and loop over the thumbnails, titles...
                IWebElement videoThumbnail = (IWebElement)video.FindElements(By.CssSelector("ytd-thumbnail"));
                Console.WriteLine(videoThumbnail.GetAttribute("src"));
            }
            Console.WriteLine("Check done...");

            ////IList<IWebElement> allVideos = new List<IWebElement>();
            //IReadOnlyCollection<IWebElement> AllVideos = Driver.FindElements(By.XPath("//*[@id='primary']/ytd-item-section-renderer[1]/div[3]/ytd-video-renderer"));
            //Console.WriteLine("Check done...");
            //Console.WriteLine(AllVideos);
            //foreach (IWebElement Video in AllVideos)
            //{
            //    Console.WriteLine(Video);
            //    Console.WriteLine(Video.Text);
            //    var VideoLink = Video.FindElements(By.XPath("//*[@id='thumbnail']/img"));
            //    System.Threading.Thread.Sleep(500);
            //    Console.WriteLine(VideoLink);
            //}
            //Console.WriteLine("Check done...");
        }
    }
}
