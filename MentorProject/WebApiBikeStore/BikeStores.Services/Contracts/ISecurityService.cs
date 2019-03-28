using System.Collections.Generic;
using BikeStores.Data;
using BikeStores.Data.Models;
using BikeStores.Data.Repository;

namespace BikeStores.Services.Contracts
{
    public interface ISecurityService: IRepository<user>
    {
        ProcessResult<UserAuthModel> BuildUserAuthObject(user authUser);
        ProcessResult<IEnumerable<userClaim>> GetUserClaim(user authUser);
        ProcessResult<UserAuthModel> ValidateUser(user user);
    }
}