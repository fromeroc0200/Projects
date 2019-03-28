using BikeStores.Data.Models;
using BikeStores.Data.Repository;
using BikeStores.Services.Contracts;
using BikeStores.Services.Services;
using BikeStores.Services.UnityOfWork;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BikeStores.WebApi.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        //--Creamos el servicio para ser consumido
        IUnityOfWork _unityOfWork;
        ILoggerManager _logger;
        ModelFactory _factoryModel;

        //--Inyectamos la dependencia IProductsService
        public ProductsController(IUnityOfWork unityOfWork, ILoggerManager loggerManager)
        {
            _factoryModel = new ModelFactory();
            _logger = loggerManager;
            _unityOfWork = unityOfWork;
        }
        
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            try
            {
                _logger.LogInfo("Fetching all the products from the storage");
                var result = _unityOfWork.Products.GetAll();
                if (result.HasError)
                {
                    return Request.CreateResponse(result.StatusCode, result);
                }
                var products = result.Content.Select(p => _factoryModel.Create(p));
                var count = products != null ? products.Count() : 0;

                _logger.LogInfo($"Returning {count} products.");

                return Request.CreateResponse(HttpStatusCode.OK, products);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("{productId:int}")]
        public HttpResponseMessage Get(int productId)
        {
            _logger.LogInfo("Fetching one product from the storage");

            ProcessResult<products> result = _unityOfWork.Products.Get(productId);
            if (result.HasError)
            {
                return Request.CreateResponse(result.StatusCode, result);
            }

            var product = _factoryModel.Create(result.Content);
            
            if (product == null)
            {
                _logger.LogWarn($"Product ID: {productId} Not Found.");
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            _logger.LogInfo($"Returning product with ID: {productId}.");

            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post([FromBody] ProductsModel product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogWarn($"Model product is not correct. Details: {ModelState}");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

                _logger.LogInfo("Fetching entity product for insert");
                ProcessResult<products> result = _factoryModel.Parse(product);

                if (result.HasError)
                {
                    Request.CreateResponse(HttpStatusCode.BadRequest, result);
                }

                var entity = result.Content;

                if (entity == null)
                {
                    _logger.LogWarn($"Product is not correct.");
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                _logger.LogInfo("Insert entity product.");
                _unityOfWork.Products.Add(entity);
                _unityOfWork.Complete();
                _logger.LogInfo("Product inserted, retuning response.");

                var msg = Request.CreateResponse(HttpStatusCode.Created, product);
                msg.Headers.Location = new Uri(Request.RequestUri + product.product_id.ToString());

                return msg;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [HttpPatch]
        [AcceptVerbs("POST", "PATCH")]
        [Route("{productId:int}")]
        public HttpResponseMessage Patch(int productId, ProductsModel product)
        {

            try
            {
                #region Validation Product

                if (!ModelState.IsValid)
                {
                    _logger.LogWarn($"Model product is not correct. Details: {ModelState}");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

                if (productId != product.product_id)
                {
                    _logger.LogWarn($"Product is not registered");
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                #endregion

                #region Convert ProductModel to product entity

                _logger.LogInfo("Fetching entity product for insert");
                ProcessResult<products> result = _factoryModel.Parse(product);
                if (result.HasError)
                {
                    _logger.LogWarn($"Product is not registered");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, result);
                }

                #endregion

                var entity = result.Content;
                #region Update Process

                _logger.LogInfo($"Updating Product with ID: {productId}.");
                var res = _unityOfWork.Products.UpdateProduct(productId, entity);
                if (res.HasError)
                {
                    res.Message = $"Update process: {res.Message}";
                    _logger.LogWarn(res.Message);
                }
                else
                {
                    _logger.LogInfo($"Product with ID: {productId} was updated.");
                }
                
                return Request.CreateResponse(res.StatusCode, res);

                #endregion
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("{productId:int}")]
        public HttpResponseMessage Delete(int productId)
        {
            try
            {
                #region Serch productId

                _logger.LogInfo("Fetching entity product for delete");
                var result = _unityOfWork.Products.Get(productId);

                if(result.HasError)
                {
                    result.Message = $"Delete process: {result.Message}";
                    _logger.LogWarn(result.Message);
                    return Request.CreateResponse(result.StatusCode, result);
                }

                #endregion

                var entity = result.Content;

                #region Delete Product

                _logger.LogInfo($"Deleting product with ID: {productId}.");
                var res = _unityOfWork.Products.Remove(entity);
                _unityOfWork.Complete();
                if (res.HasError)
                {
                    res.Message = $"Delete process: {res.Message}";
                    _logger.LogWarn(res.Message);
                }                    
                else
                    _logger.LogInfo($"Product with ID: {productId} was deleted."); 

                return Request.CreateResponse(res.StatusCode, res);
                
                #endregion
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
