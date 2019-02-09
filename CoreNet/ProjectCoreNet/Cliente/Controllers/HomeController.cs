using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cliente.Models;
using System.Net.Http;

namespace Cliente.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44324");
                var response1 = client.PostAsJsonAsync<Pruebas.Obj.RequestObj>("/api/values/Consumo",
                    new Pruebas.Obj.RequestObj() { Id = "1", Text = "Hola" }).Result;

                string jsonResult = String.Empty;
                if (response1.IsSuccessStatusCode)
                {
                    jsonResult = response1.Content.ReadAsStringAsync().Result;
                }
                string Url = String.Format("https://localhost:44324/api/values/ConsumoGet?Object={0}",
                        Newtonsoft.Json.JsonConvert.SerializeObject(new Pruebas.Obj.RequestObj() { Id = "1", Text = "Hola " }));
                var response2 = client.GetAsync(Url).Result;

                if (response2.IsSuccessStatusCode)
                {
                    jsonResult = response2.Content.ReadAsStringAsync().Result;
                }
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
