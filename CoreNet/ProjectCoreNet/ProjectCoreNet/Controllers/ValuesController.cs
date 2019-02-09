using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectCoreNet.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        #region GET Example HTTP

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return $"value {id}";
        //}

        //// GET api/<controller>/123?query=hello
        //[HttpGet("{id:int}")]
        //public string Get(int id, string query)
        //{
        //    return $"value {id} string= {query}";
        //}

        //// GET api/<controller>/123?query=hello&id=123
        //[HttpGet("{id:int}")]
        //public string Get([FromQuery] int id, string query)
        //{
        //    return $"value {id} string= {query}";
        //}

        #endregion

        #region POST HTTP IActionResult Example

        //// POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]Value value)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        throw new InvalidOperationException("Invalido");
        //    }
        //}

        // GET api/<controller>/123?query=hello&id=123
        //[HttpGet("{id}")]
        //public IActionResult Get([FromQuery] int id, string query)
        //{
        //    return Ok(new Value { Id = id, Text = "value " + id });
        //}

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Value value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new { id = value.Id }, value);
        }

        // POST api/values/ConsumoGet?Object={0}
        [HttpPost]
        [Route("Consumo")]
        public JsonResult ConsumoPosts([FromBody] Pruebas.Obj.RequestObj request)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            //System.Net.Http.Formatting.JsonMediaTypeFormatter jsonMediaTypeFormatter = new System.Net.Http.Formatting.JsonMediaTypeFormatter();
            List<Pruebas.Obj.ResponseObj> responseObjs = null;

            try
            {
                responseObjs = new List<Pruebas.Obj.ResponseObj>
                {
                    new Pruebas.Obj.ResponseObj() { Id = "1", Text = "Hola" },
                    new Pruebas.Obj.ResponseObj() { Id = "2", Text = "Hola" },
                    new Pruebas.Obj.ResponseObj() { Id = "3", Text = "Hola" },
                    new Pruebas.Obj.ResponseObj() { Id = "4", Text = "Hola" },
                    new Pruebas.Obj.ResponseObj() { Id = "5", Text = "Hola" },
                    new Pruebas.Obj.ResponseObj() { Id = "6", Text = "Hola" },
                    new Pruebas.Obj.ResponseObj() { Id = "7", Text = "Hola" },
                    new Pruebas.Obj.ResponseObj() { Id = "8", Text = "Hola" },
                    new Pruebas.Obj.ResponseObj() { Id = "9", Text = "Hola" },
                    new Pruebas.Obj.ResponseObj() { Id = "10", Text = "Hola" }
                };
                response.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(responseObjs), System.Text.Encoding.UTF8, "application/json");
                response.RequestMessage = new HttpRequestMessage();
                response.RequestMessage.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(responseObjs), System.Text.Encoding.UTF8, "application/json");

            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
                response.Content = new StringContent(ex.Message, System.Text.Encoding.UTF8, "application/json");
            }
            return new JsonResult(responseObjs);

        }

        [HttpGet("{Object}")]
        [Route("ConsumoGet")]
        public JsonResult ConsumoGet([FromQuery] string Object)
        {
            try
            {
                var json = Newtonsoft.Json.JsonConvert.DeserializeObject<Pruebas.Obj.RequestObj>(Object);

                return new JsonResult(new Pruebas.Obj.ResponseObj() { Id = json.Id, Text = json.Text });
            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
        }


        #endregion

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            response.Content = new StringContent("", System.Text.Encoding.UTF8, "application/");


        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Value
    {
        public int Id { get; set; }
        [MinLength(3)]
        public string Text { get; set; }
    }
}
