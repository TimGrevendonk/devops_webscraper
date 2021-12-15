using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using webscraper.Views;
using webscraper.Actions;

namespace webscraper
{
    public class Webscraper
    {
        public static void Main(string[] args)
        {
            do
            {
                    // Show the home page under "views"
                HomePage.Show();
                    // Set the selection made to uppercase and take only the first letter.
                String selection = Console.ReadLine().Substring(0, 1).ToUpper();
                    // Y = youtube query.
                if (selection == "Y")
                {
                        // make a driver and browse to Youtube.
                    ChromeDriver Driver = StartDriver.Website("https://www.youtube.com/");
                        // Click Youtube "accept Terms" button.
                    Driver.FindElement(By.XPath("//*[@id='content']/div[2]/div[5]/div[2]/ytd-button-renderer[2]")).Click();
                        // sleep/wait for 1,5 seconds to let the items/page load, or else the input field is not fillable.
                    System.Threading.Thread.Sleep(1500);
                        // Show the prompt to enter a search value.
                    InputYoutubeSearch.Show();
                    string searchTerm = Console.ReadLine();
                        // Do a youtube search, and filter on most recent.
                    YoutubeSearch.SearchForVideos(Driver, searchTerm);
                        // get the info of the top 5 youtube video results.
                    YoutubeVideoResults.Show();
                    QueryYoutubeVideos.QueryVideos(Driver);
                    // Any input will return to the big loop.
                    Console.ReadLine();
                }
                    // M = My own webpage.
                if (selection == "M")
                {
                        // Show the prompt to enter a URL
                    EnterWebsiteName.Show();
                    string website = Console.ReadLine();
                        // make a driver and browse to the given website.
                    ChromeDriver Driver = StartDriver.Website("https://www." + website);
                }
            } while (true);
        }
    }
}
