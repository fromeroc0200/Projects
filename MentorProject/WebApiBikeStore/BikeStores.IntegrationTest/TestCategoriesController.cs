using System;
using BikeStores.Data;
using BikeStores.Data.Repository;
using BikeStores.Services.Services;
using BikeStores.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeStores.IntegrationTest
{
    [TestClass]
    public class TestCategoriesController
    {
        [TestMethod]
        public void GetAllCategories_ShoulGetAllCategories()
        {
            //var context = new TestBikeStoreContext();
            //context.categories.Add(new categories() {
            //                                            category_id =1,
            //                                            category_name ="category01"
            //                                        });

            //var controller = new CategoriesController(new CategoriesService(context), new LoggerManager())
            //{
            //    Request = new System.Net.Http.HttpRequestMessage(),
            //    Configuration = new System.Web.Http.HttpConfiguration()
            //};
            //var result = controller.Get();
            //var cont = result.Content.ReadAsStringAsync().Result;

            //Assert.IsNotNull(result);
            //Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);
        }
    }
}
