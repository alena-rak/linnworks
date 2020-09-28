using LinnworkTestTask.api.main;
using RestSharp;
using RestSharp.Serialization.Json;

namespace LinnworkTestTask.api.model
{
    public static class CategoryActions
    {
        public static void SetIdForCategoryFromResponse(Category category, IRestResponse response)
        {
            category.categoryId = new JsonDeserializer().Deserialize<Category>(response).categoryId;
        }

        public static void CreateCategoryViaApi(Category category)
        {
            var json = new JsonObject();
            json.Add("categoryName", category.Name());
            var createCategoryResponse = RestAdapter.POST("/Category/Create", json);
            SetIdForCategoryFromResponse(category, createCategoryResponse);
        }
    }
}