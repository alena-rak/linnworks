using System;
using LinnworkTestTask.main.application;
using LinnworkTestTask.main.elements;
using OpenQA.Selenium;

namespace LinnworkTestTask.main.Pages
{
    public class LoginPage : AbstractPage
    {
        private String pageRelativeUrl = "login";

        private TextBox textBoxToken = new TextBox(By.XPath("//input[@id='token']"));
        private Button buttonLogIn = new Button(By.XPath("//button[@type='submit']"));
        private Label labelError = new Label(By.XPath("//div[contains(@class, 'alert-danger')]"));
        private Label labelAppLogin = new Label(By.XPath("//app-login"));
        
        public LoginPage Open()
        {
            base.Open(pageRelativeUrl);
            return this;
        }
        
        public CategoriesPage LogIn(String token)
        {
            textBoxToken.setValue(token);
            buttonLogIn.click();
            return new CategoriesPage();
        }

        public String GetLoginErrorText()
        {
            return labelError.Text();
        }
        
        public bool IsLoginButtonEnabled()
        {
            return buttonLogIn.Enabled();
        }

        public bool IsPageOpened()
        {
            return labelAppLogin.Present();
        }
    }
}