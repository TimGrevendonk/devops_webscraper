using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webscraper.Actions
{
    class QuerySiteInfo
    {
        public static void YoutubeVideos()
        {
            // Find all the videos (loaded in the page).
            IList<IWebElement> videos = Globals.driver.FindElements(By.Id("dismissible"));
            // For the first 5 videos print the Title to the console.
            for (int index = 0; index < 5; index++)
            {
                Console.WriteLine("- - video " + (index + 1) + " info - -");
                IWebElement videoTitle = (IWebElement)videos[index].FindElement(By.Id("video-title"));
                Console.WriteLine("Title= " + videoTitle.Text);

                //IWebElement channelName = (IWebElement)videos[index].FindElement(By.Id("channel-name"));
                IWebElement channelName = (IWebElement)videos[index].FindElement(By.XPath("/html/body/ytd-app/div/ytd-page-manager/ytd-search/div[1]/ytd-two-column-search-results-renderer/div/ytd-section-list-renderer/div[2]/ytd-item-section-renderer/div[3]/ytd-video-renderer[1]/div[1]/div/div[2]/ytd-channel-name/div/div/yt-formatted-string/a"));
                Console.WriteLine("Channel= " + channelName.Text);

                //IWebElement channelviews = (IWebElement)videos[index].FindElement(By.XPath("//*[@id='metadata-line']/span[1]"));
                IWebElement channelViews = (IWebElement)videos[index].FindElement(By.XPath("//*/ytd-video-meta-block/div[1]/div[2]/span[1]"));
                Console.WriteLine("Views= " + channelViews.Text);
                    // 
                IWebElement channelLink = (IWebElement)videos[index].FindElement(By.Id("img"));
                Console.WriteLine(channelLink.GetAttribute("src"));
                // One blank line for console readability.
                Console.WriteLine("");
            }
        }

        public static void IndeedJobs()
        {
                // Get the jobs shown on the page.
            IList<IWebElement> allJobs = Globals.driver.FindElements(By.XPath("//a[contains(@class, 'result')]"));
                // From those jobs, get info per job.
            foreach(IWebElement job in allJobs)
            {
                    // Get the job title.
                IWebElement jobTitle = job.FindElement(By.CssSelector("h2[class*='jobTitle'] span[title]"));
                Console.WriteLine("Title= " + jobTitle.Text);
                    // The name of the company.
                IWebElement companyName = job.FindElement(By.CssSelector("span[class='companyName']"));
                Console.WriteLine("Company= " + companyName.Text);
                    // The location of the job/company.
                IWebElement jobLocation = job.FindElement(By.CssSelector("div[class='companyLocation']"));
                Console.WriteLine("Location= " + jobLocation.Text);
                    // The link of the job advertisment.
                Console.WriteLine(job.GetAttribute("href"));
                    // One blank line for console readability.
                Console.WriteLine("");
            }
        }

        public static void BellOfLostSoulsPosts()
        {
            // div class="column-posts" =posts table.
            IList<IWebElement> allPosts = Globals.driver.FindElements(By.TagName("article"));
            foreach (IWebElement post in allPosts)
            {
                    // Find the title tga of the post, and the text under it.
                IWebElement postTitle = post.FindElement(By.TagName("h2"));
                Console.WriteLine("Title= " + postTitle.Text);
                    // Find the tag with the autor, then the name without reading time.
                IWebElement postAuthor = post.FindElement(By.CssSelector("span[class='sub-title'] a"));
                Console.WriteLine("Author= " + postAuthor.Text);
                    // Find the Url tag, then the a tag under it for the href.
                IWebElement postUrl = post.FindElement(By.CssSelector("div[class='entry-media']")).FindElement(By.TagName("a"));
                Console.WriteLine(postUrl.GetAttribute("href"));
                    // Print 1 empty line for console readability
                Console.WriteLine();
            }
            // Click away (christmas) add video.
            System.Threading.Thread.Sleep(8000);
            AcceptPopupButtons.TryAll();
        }
    }
}
