using NUnit.Framework;

namespace LinnworkTestTask
{
    [TestFixture]
    [Category("UiTests")]
    public class LogoutTest : AbstractUiTest
    {
        [Test]
        public void testLogout()
        {
            loginPage.Open()
                     .LogIn(LOGIN_TOKEN)
                     .LogOut();

            Assert.True(homePage.IsPageOpened(), "Home page should be opened");
        }   
    }
}