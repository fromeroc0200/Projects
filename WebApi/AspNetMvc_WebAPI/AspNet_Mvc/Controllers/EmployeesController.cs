using AspNet_Mvc.Models;
using AspNet_Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNet_Mvc.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeClient client = new EmployeeClient();
            ViewBag.ListEmployees = client.FillAll();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModel employeeViewModel)
        {
            EmployeeClient employeeClient = new EmployeeClient();

            employeeClient.CreateEmployee(employeeViewModel.Employee);

            return RedirectToAction("Index");
        }

        
        public ActionResult Delete(int id)
        {
            EmployeeClient employeeClient = new EmployeeClient();

            employeeClient.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            EmployeeClient employeeClient = new EmployeeClient();
            EmployeeViewModel evm = new EmployeeViewModel();
            evm.Employee = employeeClient.FindEmployee(id);
            return View("Edit", evm);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeViewModel employeeViewModel)
        {
            EmployeeClient employeeClient = new EmployeeClient();

            employeeClient.EditEmployee(employeeViewModel.Employee);
            return RedirectToAction("Index");
        }
    }
}