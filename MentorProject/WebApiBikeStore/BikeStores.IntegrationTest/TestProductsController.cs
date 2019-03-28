using BikeStores.Data;
using BikeStores.Data.Models;
using BikeStores.Data.Repository;
using BikeStores.Services.Services;
using BikeStores.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace BikeStores.IntegrationTest
{
    [TestClass]
    public class TestProductsController
    {
        [TestMethod]
        public void Get_GetAllProducts_ShouldGetAllProducts()
        {
            ////Arrange
            //var context = new TestBikeStoreContext();
            //context.products.Add(new products { product_id = 1, brand_id = 1, product_name = "prod", category_id = 1, list_price = 0, model_year = 90 });
                
            //var controller = new ProductsController(new ProductsService(context),
            //    new LoggerManager())
            //{
            //    Request = new System.Net.Http.HttpRequestMessage(),
            //    Configuration = new System.Web.Http.HttpConfiguration()
            //};

            ////Act
            //var result = controller.Get();
            //var cont = result.Content.ReadAsStringAsync().Result;
            

            ////Assert
            //Assert.IsNotNull(result);
            //Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);
            
        }
    }
}
