using Employees.Data;
using Employees.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Employees.WebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        IEmployeesServices _employeesServices;
        public EmployeesController(IEmployeesServices employeesServices)
        {
            this._employeesServices = employeesServices;
        }

        [HttpGet]
        public IQueryable<Employee> Get()
        {
            return _employeesServices.GetEmployees();
        }
    }
}
