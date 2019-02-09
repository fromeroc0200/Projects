using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        CRUDDBEntities db = new CRUDDBEntities();
        //--api/employees
        [HttpGet]
        public IQueryable<Employee> GetEmployees()
        {
            return db.Employee;
        }

        [HttpGet]
        public IHttpActionResult GetEmployee(int id)
        {
            try
            {
                Employee employee = db.Employee.Find(id);
                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                db.Employee.Add(employee);
                db.SaveChanges();
                return Ok();
            }
            catch (DbUpdateException)
            {
                if (ExistEmployee(employee.EmployeeId))
                    return Conflict();
                else
                    throw;
            }
        }

        [HttpPut]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != employee.EmployeeId)
                return BadRequest();
            try
            {
                db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (ExistEmployee(id))
                    return NotFound();
                else
                    throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            try
            {
                Employee emp = db.Employee.Find(id) as Employee;
                if (emp == null)
                    return NotFound();

                db.Employee.Remove(emp);
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                
                throw;
            }
        }

        private bool ExistEmployee(int employeeId)
        {
            return db.Employee.Count(x => x.EmployeeId == employeeId) > 0;
        }
    }
}
