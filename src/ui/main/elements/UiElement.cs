using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LinnworkTestTask.main.utils;
using LinnworkTestTask.main.webdriver;
using OpenQA.Selenium;

namespace LinnworkTestTask.main.elements
{
    
    public abstract class UiElement
    {
        protected By by;

        public UiElement(By by)
        {
            this.@by = by;
        }
        
        protected IWebDriver Driver()
        {
            return BrowserFactory.Driver;
        }

        public void click()
        {
            Logger.Info("click on element " + by.ToString());
            Driver().FindElement(by).Click();
        }

        public bool Displayed()
        {
            Logger.Info("check if displayed for element " + by.ToString());
            return Driver().FindElement(by).Displayed;
        }
        
        public bool Present()
        {
            Logger.Info("check if present for element " + by.ToString());
            return Driver().FindElements(by).Count > 0;
        }

        public String Text()
        {
            Logger.Info("get text for element for element " + by.ToString());
            return Driver().FindElement(by).Text;
        }

        public bool Enabled()
        {
            Logger.Info("check if enabled for element " + by.ToString());
            return Driver().FindElement(by).Enabled;
        }

        public UiElement FormatLocator(String value)
        {
            String locator = by.ToString().Remove(0, by.ToString().IndexOf(" ") + 1);;
            by = By.XPath(String.Format(locator, value));
            return this;
        }

    }
}