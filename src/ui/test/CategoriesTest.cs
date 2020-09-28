using LinnworkTestTask.main.utils;
using NUnit.Framework;

namespace LinnworkTestTask
{
    [TestFixture]
    [Category("UiTests")]
    public class CategoriesTest : AbstractUiTest
    {

        [Test]
        public void testCreateCategory()
        {
            var categoryName = "Category" + RandomStringUtil.RandomAlphaNumericString(5);
            loginPage.Open()
                .LogIn(LOGIN_TOKEN)
                .ClickCreateCategory()
                .createCategory(categoryName);

            Assert.True(categoriesPage.IsCategoryPresent(categoryName), "Created category is not present in categories list");
        }
        
        [Test]
        public void testDeleteCategory()
        {
            var categoryName = "Category" + RandomStringUtil.RandomAlphaNumericString(5);
            loginPage.Open()
                .LogIn(LOGIN_TOKEN)
                .ClickCreateCategory()
                .createCategory(categoryName)
                .DeleteCategory(categoryName);
            
            Assert.That(() => categoriesPage.IsCategoryPresent(categoryName), 
                Is.False.After( delayInMilliseconds: 3000, pollingInterval: 100), "Deleted category is present in categories list");
        }
    }
}