using LinnworkTestTask.main.elements;
using OpenQA.Selenium;

namespace LinnworkTestTask.main.Pages
{
    public class HomePage : AbstractPage
    {
        private Label labelAppHome = new Label(By.XPath("//app-home"));
        
        public bool IsPageOpened()
        {
            return labelAppHome.Present();
        }
    }
}