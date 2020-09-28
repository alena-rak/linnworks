using System;
using LinnworkTestTask.main.application;
using LinnworkTestTask.main.Pages;
using LinnworkTestTask.main.utils;
using NUnit.Framework;

namespace LinnworkTestTask
{
    public abstract class AbstractUiTest
    {
        private LinnworksTestApplication app = new LinnworksTestApplication();
        protected HomePage homePage = new HomePage();
        protected LoginPage loginPage = new LoginPage();
        protected CategoriesPage categoriesPage = new CategoriesPage();
        protected String LOGIN_TOKEN = ConfigReader.GetLoginToken();
        
        [SetUp]
        public void Set_Up()
        {
            app.OpenApp();
        }
        
        [TearDown]
        public void Tear_Down()
        {
            app.CloseApp();
        }
    }
}