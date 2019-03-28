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
    [RoutePrefix("api/security")]
    public class SecurityController : ApiController
    {
        ILoggerManager _logger;
        IUnityOfWork _unityOfWork;
        IProductsService _productsService;
        ModelFactory _factoryModel;

        public SecurityController(IUnityOfWork unityOfWork, 
            //IProductsService productsService, 
            ILoggerManager logger)
        {
            this._logger = logger;
            this._unityOfWork = unityOfWork;
            //this._productsService = productsService;
            _factoryModel = new ModelFactory();
        }

        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login([FromBody]UserModel user)
        {
            try
            {
                _logger.LogInfo("Fetching all the products from the storage");
                var usr = _factoryModel.Parse(user);
                
                if (usr.HasError)
                {
                    return Request.CreateResponse(usr.StatusCode, usr);
                }
                var authUser = _unityOfWork.Security.ValidateUser(usr.Content);
                if (authUser.HasError)
                {
                    return Request.CreateResponse(authUser.StatusCode, authUser);
                }
                if (!authUser.Content.IsAuthenticated)
                {
                    Request.CreateResponse(HttpStatusCode.NotFound, "Invalid User/Password");
                }

                _logger.LogInfo($"Login success.");

                return Request.CreateResponse(HttpStatusCode.OK, authUser.Content);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
