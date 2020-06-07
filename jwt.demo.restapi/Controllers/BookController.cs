using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jwt.demo.restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<string> Get()
        {
            return new string[] { "ASP", "C#" };
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public JsonResult Post()
        {
            return new JsonResult("Create  Book ...");
        }
    }
}