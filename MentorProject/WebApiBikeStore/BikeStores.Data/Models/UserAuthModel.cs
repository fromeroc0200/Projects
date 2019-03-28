using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStores.Data.Models
{
    public class UserAuthModel
    {
        public UserAuthModel(): base()
        {
            UserName = "Not authorizated";
            BearerToken = string.Empty;
        }

        public string UserName { get; set; }
        public string BearerToken { get; set; }
        public bool IsAuthenticated { get; set; }

        public bool CanAccessProducts { get; set; }
        public bool CanAddProduct { get; set; }
        public bool CanSaveProduct { get; set; }
        public bool CanAccessCategory { get; set; }
        public bool CanAddCategory { get; set; }

    }
}