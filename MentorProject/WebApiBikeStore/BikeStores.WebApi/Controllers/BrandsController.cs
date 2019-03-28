using BikeStores.Data.Models;
using BikeStores.Data.Repository;
using BikeStores.Services.Contracts;
using BikeStores.Services.Services;
using BikeStores.Services.UnityOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BikeStores.WebApi.Controllers
{
    public class BrandsController : ApiController
    {
        ModelFactory _factoryModel;
        IUnityOfWork _unityOfWork;
        ILoggerManager _logger;

        public BrandsController(UnityOfWork unityOfWork, ILoggerManager logger)
        {
            this._factoryModel = new ModelFactory();
            this._unityOfWork = unityOfWork;
            this._logger = logger;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                _logger.LogInfo("Fetching all the Categorys from the storage");
                var result = _unityOfWork.Brands.GetAll();
                if (result.HasError)
                {
                    return Request.CreateResponse(result.StatusCode, result);
                }
                var Category = result.Content.Select(p => _factoryModel.Create(p));
                var count = Category != null ? Category.Count() : 0;

                _logger.LogInfo($"Returning {count} Brand.");

                return Request.CreateResponse(HttpStatusCode.OK, Category);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
