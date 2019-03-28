using Employees.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employees.Service.Services
{
    public class EmployeesServices : IEmployeesServices
    {
        CRUDDBEntities db = new CRUDDBEntities();
        public IQueryable<Employee> GetEmployees()
        {
            return db.Employee;
        }
    }
}