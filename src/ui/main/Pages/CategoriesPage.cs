using System;
using LinnworkTestTask.main.elements;
using OpenQA.Selenium;

namespace LinnworkTestTask.main.Pages
{
    public class CategoriesPage : AbstractPage
    {
        private String pageRelativeUrl = "fetch-category";
        private Label labelCategories = new Label(By.XPath("//app-fetch-category"));
        private Link linkCreateNew = new Link(By.XPath("//a[@href='/add-category']"));
        private Label labelCategoryName = new Label(By.XPath("//tbody//td[1][text()='{0}']"));
        //definitely need to write custom Table element class to avoid writing such creepy locators and
        //overall to have nice way to work with tables, i know. Not gonna do it in test task tho. Sorry, so here is my creepy locator
        private Link linkDeleteCategory = new Link(By.XPath("//tbody//td[1][text()='{0}']//ancestor::tr//td[4]//a[2]"));
        
        public CategoriesPage Open()
        {
            base.Open(pageRelativeUrl);
            return this;
        }

        public CreateEditCategoryPage ClickCreateCategory()
        {
            linkCreateNew.click();
            return new CreateEditCategoryPage();
        }

        public CategoriesPage DeleteCategory(String categoryName)
        {
            linkDeleteCategory.FormatLocator(categoryName).click();
            AcceptBrowserAlert();
            return this;
        }

        public bool IsPageOpened()
        {
            return labelCategories.Present();
        }

        public bool IsCategoryPresent(String categoryName)
        {
            return labelCategoryName.FormatLocator(categoryName).Present();
        }

    }
}