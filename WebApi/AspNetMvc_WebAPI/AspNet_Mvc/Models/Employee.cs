using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNet_Mvc.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name= "Posicion")]
        public string Position { get; set; }
        [Display(Name = "Edad")]
        public int Age { get; set; }
        [Display(Name = "Salario")]
        public decimal Salaries { get; set; }
    }
}