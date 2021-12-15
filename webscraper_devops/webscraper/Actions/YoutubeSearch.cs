using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webscraper.Actions
{
    class YoutubeSearch
    {
        public static void SearchForVideos(ChromeDriver Driver, String searchTerm)
        {
                // Find the Youtube input field.
            IWebElement SearchBarInput = Driver.FindElement(By.Name("search_query"));
                // Enter value in the field and submit it.
            SearchBarInput.SendKeys(searchTerm);
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
        }
    }
}
