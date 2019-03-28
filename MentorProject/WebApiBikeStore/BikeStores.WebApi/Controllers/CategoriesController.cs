
using BikeStores.Data;
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
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        //--Creamos el servicio para ser consumido
        IUnityOfWork _unityOfWork;
        ILoggerManager _logger;
        ModelFactory _factoryModel;


        //--Inyectamos la dependencia ICategoriesService
        public CategoriesController(IUnityOfWork unityOfWork, ILoggerManager logger)
        {
            this._factoryModel = new ModelFactory();
            this._unityOfWork = unityOfWork;
            this._logger = logger;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            try
            {
                _logger.LogInfo("Fetching all the Categorys from the storage");
                var result = _unityOfWork.Categories.GetAll();
                if (result.HasError)
                {
                    return Request.CreateResponse(result.StatusCode, result);
                }
                var Category = result.Content.Select(p => _factoryModel.Create(p));
                var count = Category != null ? Category.Count() : 0;

                _logger.LogInfo($"Returning {count} Category.");

                return Request.CreateResponse(HttpStatusCode.OK, Category);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("{categoryId:int}")]
        public HttpResponseMessage Get(int categoryId)
        {
            _logger.LogInfo("Fetching one Category from the storage");

            ProcessResult<categories> result = _unityOfWork.Categories.Get(categoryId);
            if (result.HasError)
            {
                return Request.CreateResponse(result.StatusCode, result);
            }

            var Category = _factoryModel.Create(result.Content);

            if (Category == null)
            {
                _logger.LogWarn($"Category ID: {categoryId} Not Found.");
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            _logger.LogInfo($"Returning Category with ID: {categoryId}.");

            return Request.CreateResponse(HttpStatusCode.OK, Category);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post([FromBody] CategoriesModel category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogWarn($"Model Category is not correct. Details: {ModelState}");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

                _logger.LogInfo("Fetching entity Category for insert");
                ProcessResult<categories> result = _factoryModel.Parse(category);

                if (result.HasError)
                {
                    Request.CreateResponse(HttpStatusCode.BadRequest, result);
                }

                var entity = result.Content;

                if (entity == null)
                {
                    _logger.LogWarn($"Category is not correct.");
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                _logger.LogInfo("Insert entity Category.");
                _unityOfWork.Categories.Add(entity);
                _unityOfWork.Complete();
                _logger.LogInfo("Category inserted, retuning response.");
                var msg = Request.CreateResponse(HttpStatusCode.Created, category);
                msg.Headers.Location = new Uri(Request.RequestUri + category.category_id.ToString());

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
        [Route("{categoryId:int}")]
        public HttpResponseMessage Patch(int categoryId, CategoriesModel category)
        {

            try
            {
                #region Validation Category

                if (!ModelState.IsValid)
                {
                    _logger.LogWarn($"Model Category is not correct. Details: {ModelState}");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

                if (categoryId != category.category_id)
                {
                    _logger.LogWarn($"Category is not registered");
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                #endregion

                #region Convert CategoryModel to Category entity

                _logger.LogInfo("Fetching entity Category for insert");
                ProcessResult<categories> result = _factoryModel.Parse(category);
                if (result.HasError)
                {
                    _logger.LogWarn($"Category is not registered");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, result);
                }

                #endregion

                var entity = result.Content;
                #region Update Process

                _logger.LogInfo($"Updating Category with ID: {categoryId}.");
                var res = _unityOfWork.Categories.UpdateCategory(categoryId, entity);
                if (res.HasError)
                {
                    res.Message = $"Update process: {res.Message}";
                    _logger.LogWarn(res.Message);
                }
                else
                {
                    _logger.LogInfo($"Category with ID: {categoryId} was updated.");
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
        [Route("{categoryId}")]
        public HttpResponseMessage Delete(int categoryId)
        {
            try
            {
                #region Serch CategoryId

                _logger.LogInfo("Fetching entity Category for delete");
                var result = _unityOfWork.Categories.Get(categoryId);

                if (result.HasError)
                {
                    result.Message = $"Delete process: {result.Message}";
                    _logger.LogWarn(result.Message);
                    return Request.CreateResponse(result.StatusCode, result);
                }

                #endregion

                var entity = result.Content;

                #region Delete Category

                _logger.LogInfo($"Deleting Category with ID: {categoryId}.");
                var res = _unityOfWork.Categories.Remove(entity);
                _unityOfWork.Complete();
                if (res.HasError)
                {
                    res.Message = $"Delete process: {res.Message}";
                    _logger.LogWarn(res.Message);
                }
                else
                    _logger.LogInfo($"Category with ID: {categoryId} was deleted.");

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
