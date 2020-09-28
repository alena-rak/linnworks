using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace LinnworkTestTask.main.webdriver
{
    class BrowserFactory
    {
        private static IWebDriver driver;
 
        public static IWebDriver Driver
        {
            get
            {
                if(driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return driver;
            }
            private set
            {
                driver = value;
            }
        }
 
        public static void InitBrowser()
        {
            if (driver == null)
            {
                driver = new ChromeDriver("src\\resources");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                //TODO add propertyReader and logger
            }
        }

        public static void Clean()
        {
            driver = null;
        }
    }
}