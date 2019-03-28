using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeStores.Data.Models
{
    public class UserModel
    {
        [Required()]
        public Guid UserId { get; set; }
        [Required()]
        [StringLength(255)]
        public string UserName { get; set; }
        [Required()]
        [StringLength(255)]
        public string Password { get; set; }
    }
}