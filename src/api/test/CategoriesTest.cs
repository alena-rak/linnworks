using System;
using System.Collections.Generic;
using System.Net;
using LinnworkTestTask.api.main;
using LinnworkTestTask.api.model;
using LinnworkTestTask.main.utils;
using NUnit.Framework;
using RestSharp;

namespace LinnworkTestTask.api.test
{
    [TestFixture]
    [Category("ApiTests")]
    public class CategoriesTest : AbstractApiTest
    {
        [Test]
        public void testApiCreateCategoryRestResponse()
        {
            DoApiLogin();
            Category category = new Category("Category" + RandomStringUtil.RandomAlphaNumericString(5));
            
            var json = new JsonObject();
            json.Add("categoryName", category.Name());
            
            var createCategoryResponse = RestAdapter.POST("/Category/Create", json);
            
            Assert.AreEqual(HttpStatusCode.OK, createCategoryResponse.StatusCode, 
                "Category creation failed");
        }
        
        [Test]
        public void testApiCreatedCategoryIsInTheCategoriesList()
        {
            Category category = new Category("Category" + RandomStringUtil.RandomAlphaNumericString(5));
            
            DoApiLogin();
            CategoryActions.CreateCategoryViaApi(category);
            category.stock = 0;
            
            List<Category> categories = jsonDeserializer.Deserialize<List<Category>>(RestAdapter.GET("/Category/Index"));
            CollectionAssert.Contains(categories, category, "Created category is not in categories list");
        }
        
        [Test]
        public void testApiDeleteCategoryRestResponse()
        {
            Category category = new Category("Category" + RandomStringUtil.RandomAlphaNumericString(5));
            
            DoApiLogin();
            CategoryActions.CreateCategoryViaApi(category);

            Assert.AreEqual(HttpStatusCode.OK, RestAdapter.DELETE(String.Format("/Category/Delete/{0}", category.categoryId)).StatusCode, 
                "Category deletion failed");
        }
        
        [Test]
        public void testApiDeletedCategoryIsNotInCategoriesList()
        {
            Category category = new Category("Category" + RandomStringUtil.RandomAlphaNumericString(5));
            
            DoApiLogin();
            CategoryActions.CreateCategoryViaApi(category);
            category.stock = 0;
            RestAdapter.DELETE(String.Format("/Category/Delete/{0}", category.categoryId));
            List<Category> categories = jsonDeserializer.Deserialize<List<Category>>(RestAdapter.GET("/Category/Index"));
            
            CollectionAssert.DoesNotContain(categories, category, "Deleted category is in categories list");
        }
    }
}