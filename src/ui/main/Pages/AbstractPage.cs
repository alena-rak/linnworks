using System;
using LinnworkTestTask.main.application;
using LinnworkTestTask.main.elements;
using LinnworkTestTask.main.utils;
using LinnworkTestTask.main.webdriver;
using OpenQA.Selenium;

namespace LinnworkTestTask.main.Pages
{
    public abstract class AbstractPage
    {
        private Link buttonLogOut = new Link(By.XPath("//a[@href='/logout']"));
        
        public void Open(String pageUrl)
        {
            NavigateByUrl(pageUrl);
        }
        
        private IWebDriver Driver()
        {
            return BrowserFactory.Driver;
        }
        
        public void LogOut()
        {
            buttonLogOut.click();
        }

        public void NavigateByUrl(String url)
        {
            IWebDriver driver = BrowserFactory.Driver;
            if (!Driver().Url.Equals(url))
            {
                String fullUrl = Driver().Url + url;
                Logger.Info("opening url " + fullUrl);
                Driver().Url = fullUrl;
            }
        }

        public void AcceptBrowserAlert()
        {
            Driver().SwitchTo().Alert().Accept();
        }
    }
}