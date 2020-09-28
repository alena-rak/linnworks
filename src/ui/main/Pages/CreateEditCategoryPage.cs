using System;
using LinnworkTestTask.main.elements;
using OpenQA.Selenium;

namespace LinnworkTestTask.main.Pages
{
    public class CreateEditCategoryPage : AbstractPage
    {
        private TextBox textBoxCategoryName = new TextBox(By.XPath("//input[@formcontrolname='categoryName']"));
        private Button buttonSave = new Button(By.XPath("//button[@type='submit']"));

        public CategoriesPage createCategory(String categoryName)
        {
            textBoxCategoryName.setValue(categoryName);
            buttonSave.click();
            return new CategoriesPage();
        }

        public void editCategory(String categoryName)
        {
            createCategory(categoryName);
        }
        
    }
}