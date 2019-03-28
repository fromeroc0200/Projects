using BikeStores.Data;
using BikeStores.Data.Models;
using BikeStores.Data.Repository;
using BikeStores.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace BikeStores.Services.Services
{
    public class SecurityService : Repository<user>, ISecurityService
    {
        BikeStoresEntities db = new BikeStoresEntities();

        public SecurityService(BikeStoresEntities context): base(context) { }

        public ProcessResult<UserAuthModel> ValidateUser(user user)
        {
            ProcessResult<UserAuthModel> result = new ProcessResult<UserAuthModel>();
            try
            {   
                
                var usr = db.user.Where(
                    u => u.UserName.ToLower() == user.UserName.ToLower()
                    && u.Password == user.Password).FirstOrDefault();
                if (usr != null)
                {
                    result = BuildUserAuthObject(usr);
                }
                else
                {
                    result.HasError = true;
                    result.Message = $"Invalid User/Password";
                    result.StatusCode = HttpStatusCode.NotFound;
                }
                
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = $"Something went wrong: {ex}";
                result.StatusCode = HttpStatusCode.BadRequest;
            }
            return result;
        }

        public ProcessResult<UserAuthModel> BuildUserAuthObject(user authUser)
        {
            ProcessResult<UserAuthModel> result = new ProcessResult<UserAuthModel>();
            try
            {
                result.Content = new UserAuthModel();
                result.Content.UserName = authUser.UserName;
                result.Content.IsAuthenticated = true;
                result.Content.BearerToken = Guid.NewGuid().ToString();

                var claims = GetUserClaim(authUser);
                if (!claims.HasError)
                {
                    foreach (var claim in claims.Content)
                    {
                        typeof(UserAuthModel).GetProperty(claim.ClaimType)
                            .SetValue(result.Content, claim.ClaimValue == "1" ? true : false);
                    }
                }
                else
                {
                    result.HasError = true;
                    result.Message = claims.Message;
                    result.Content = null;
                    result.StatusCode = claims.StatusCode;
                    return result;
                }

                result.Message = $"Build Object complete";
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = $"Something went wrong: {ex}";
                result.StatusCode = HttpStatusCode.BadRequest;
            }
            return result;
        }

        public ProcessResult<IEnumerable<userClaim>> GetUserClaim(user authUser)
        {
            ProcessResult<IEnumerable<userClaim>> result = new ProcessResult<IEnumerable<userClaim>>();
            try
            {
                using (var db = new BikeStoresEntities())
                {
                    var usrClaim = db.userClaim.Where(u => u.UserId == authUser.UserId);
                    if(usrClaim == null)
                    {
                        result.HasError = true;
                        result.Message = "Not Found userClaim";
                        result.StatusCode = HttpStatusCode.NotFound;
                    }
                    else
                    {
                        result.Content = usrClaim.ToList();
                        result.Message = "Success get all userClaim";
                        result.StatusCode = HttpStatusCode.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = $"Something went wrong: {ex}";
                result.StatusCode = HttpStatusCode.BadRequest;
            }
            return result;
        }

    }
}