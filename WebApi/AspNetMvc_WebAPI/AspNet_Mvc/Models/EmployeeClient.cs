using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;

namespace AspNet_Mvc.Models
{
    public class EmployeeClient
    {
        const string _baseUrl = "http://localhost:61103/api/";

        public IEnumerable<Employee> FillAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Employees").Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                return null;
            }
            catch (Exception ex)
            {
                var r = ex.Message;
                return null;
            }
        }


        public Employee FindEmployee(int employeeId)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync($"Employees/{employeeId}").Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<Employee>().Result;
                return null;
            }
            catch (Exception ex)
            {
                var r = ex.Message;
                return null;
            }
        }

        public bool CreateEmployee(Employee employee)
        {
            bool result = false;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Employees",employee).Result;
                result = response.IsSuccessStatusCode;
                return result;
            }
            catch (Exception ex)
            {
                var r = ex.Message;
                return result;
            }
        }


        public bool EditEmployee(Employee employee)
        {
            bool result = false;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync($"Employees/{employee.EmployeeId}", employee).Result;
                result = response.IsSuccessStatusCode;
                return result;
            }
            catch (Exception ex)
            {
                var r = ex.Message;
                return result;
            }
        }

        public bool DeleteEmployee(int id)
        {
            bool result = false;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync($"Employees/{id}").Result;
                result = response.IsSuccessStatusCode;
                return result;
            }
            catch (Exception ex)
            {
                var r = ex.Message;
                return result;
            }
        }
    }
}