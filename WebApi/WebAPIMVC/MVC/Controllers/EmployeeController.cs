using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<MvcEmployeeModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employees").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<MvcEmployeeModel>>().Result;
            return View(empList);
        }

        
        public ActionResult AddOrEdit(int id = 0)
        {
            if(id==0)
                return View(new MvcEmployeeModel());
            else
            {
                HttpResponseMessage request = GlobalVariables.WebApiClient.GetAsync(string.Format("Employees/{0}", id)).Result;
                return View(request.Content.ReadAsAsync<MvcEmployeeModel>().Result);
            }
                
                
        }
        [HttpPost]
        public ActionResult AddOrEdit(MvcEmployeeModel emp)
        {
            if(emp.EmployeeId == 0)
            {
                HttpResponseMessage request = GlobalVariables.WebApiClient.PutAsJsonAsync("Employees", emp).Result;
                TempData["SuccessMessage"] = "Save Successfully";
            }
            else
            {
                HttpResponseMessage request = GlobalVariables.WebApiClient.PutAsJsonAsync(string.Format("Employees/{0}", emp.EmployeeId), emp).Result;
                TempData["SuccessMessage"] = "Update Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            HttpResponseMessage request = GlobalVariables.WebApiClient.DeleteAsync(string.Format("Employees/{0}", Id)).Result;
            TempData["SuccessMessage"] = "Delete Successfully";
            return RedirectToAction("Index");
        }
    }
}