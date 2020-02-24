using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BstarApi.Models;
using Newtonsoft.Json;
namespace BstarApi.Controllers
{
    public class BStarController : Controller
    {
        static string LOOL =Directory.GetCurrentDirectory();
        static ArbolStar metodosArbol = new ArbolStar(7, $"\\Arbol.txt");
        // GET api/values
        public string Get()
        {
            return "Postman";
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]object value)
        {
            var lol = value.ToString();
            var objeto = JsonConvert.DeserializeObject<Bebida>(lol);
            metodosArbol.Insertar(objeto);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
