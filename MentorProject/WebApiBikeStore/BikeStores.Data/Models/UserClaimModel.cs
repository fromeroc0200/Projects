using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeStores.Data.Models
{
    public class UserClaimModel
    {
        [Required()]
        public Guid ClaimId { get; set; }
        [Required()]
        public Guid UserId { get; set; }
        [Required()]
        public string ClaimType { get; set; }
        [Required()]
        public string ClaimValue { get; set; }

        //public user user { get; set; }
    }
}