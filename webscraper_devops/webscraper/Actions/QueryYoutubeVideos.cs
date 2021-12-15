using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webscraper.Actions
{
    class QueryYoutubeVideos
    {
        public static void QueryVideos(ChromeDriver Driver)
        {
            // Find all the videos (loaded in the page).
            IList<IWebElement> videos = Driver.FindElements(By.Id("dismissible"));
            // For the first 5 videos print the Title to the console.
            for (int index = 0; index < 5; index++)
            {
                Console.WriteLine("- - video " + (index + 1) + " info - -");
                IWebElement videoTitle = (IWebElement)videos[index].FindElement(By.Id("video-title"));
                Console.WriteLine(videoTitle.Text);

                //IWebElement channelName = (IWebElement)videos[index].FindElement(By.Id("channel-name"));
                IWebElement channelName = (IWebElement)videos[index].FindElement(By.XPath("/html/body/ytd-app/div/ytd-page-manager/ytd-search/div[1]/ytd-two-column-search-results-renderer/div/ytd-section-list-renderer/div[2]/ytd-item-section-renderer/div[3]/ytd-video-renderer[1]/div[1]/div/div[2]/ytd-channel-name/div/div/yt-formatted-string/a"));
                Console.WriteLine(channelName.Text);

                //IWebElement channelviews = (IWebElement)videos[index].FindElement(By.XPath("//*[@id='metadata-line']/span[1]"));
                IWebElement channelViews = (IWebElement)videos[index].FindElement(By.XPath("//*/ytd-video-meta-block/div[1]/div[2]/span[1]"));
                Console.WriteLine(channelViews.Text);
                    // 
                IWebElement channelLink = (IWebElement)videos[index].FindElement(By.Id("img"));
                Console.WriteLine(channelLink.GetAttribute("src"));
            }
        }
    }
}
