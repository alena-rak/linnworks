using System;
using LinnworkTestTask.main.utils;
using OpenQA.Selenium;

namespace LinnworkTestTask.main.elements
{
    public class TextBox : UiElement
    {
        public TextBox(By by) : base(by)
        {
        }

        public void setValue(String value)
        {
            Logger.Info(String.Format("set value {0} for element {1}", value, @by.ToString()));
            if (value != null)
            {
                Driver().FindElement(this.@by).Clear();
                Driver().FindElement(this.@by).SendKeys(value);
            }
            
        }
        
    }
}