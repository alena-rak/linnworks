using LinnworkTestTask.main.utils;
using NUnit.Framework;

namespace LinnworkTestTask
{
    [TestFixture]
    [Category("UiTests")]
    class LoginTest : AbstractUiTest
    {
        [Test]
        public void testLoginSuccessful()
        {
            loginPage.Open()
                     .LogIn(LOGIN_TOKEN);

            Assert.True(categoriesPage.IsPageOpened(), "Categories page should be opened");
        }
        
        [Test]
        public void testLoginFailedForIncorrectToken()
        {
            loginPage.Open()
                     .LogIn(RandomStringUtil.RandomAlphaNumericString(12));

            Assert.False(categoriesPage.IsPageOpened(), "Categories page should not be opened");
            Assert.AreEqual(loginPage.GetLoginErrorText(), "Oops!\r\nInvalid token.", "Should show Invalid token error");
        }
        
        [Test]
        public void testLoginButtonDisabled()
        {
            loginPage.Open();

            Assert.False(loginPage.IsLoginButtonEnabled(), "Login button should be disabled if no token in field");
        }

        [Test]
        public void testCategoriesPageRedirectsToLoginIfNotLogged()
        {
            categoriesPage.Open();
            
            Assert.False(categoriesPage.IsPageOpened(), "Categories page should not be opened");
            Assert.True(loginPage.IsPageOpened(), "Login page should be opened");
        }

    }
}