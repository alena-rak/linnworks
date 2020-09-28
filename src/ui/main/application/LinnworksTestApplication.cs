using LinnworkTestTask.main.utils;
using LinnworkTestTask.main.webdriver;

namespace LinnworkTestTask.main.application
{
    public class LinnworksTestApplication
    {

        public void OpenApp()
        {
            BrowserFactory.InitBrowser();
            BrowserFactory.Driver.Manage().Window.Maximize();
            BrowserFactory.Driver.Url = ConfigReader.GetAppUrl();
        }

        public void CloseApp()
        {
            BrowserFactory.Driver.Close();
            BrowserFactory.Driver.Quit();
            BrowserFactory.Clean();
        }
    }
}