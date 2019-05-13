using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CIKataBackEnd.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            var returnString = string.Empty;

            if (id > 5)
            {
                returnString = "biggun";
            }
            else
            {
                returnString = "wee one";
            }

            return new JsonResult(returnString);
        }
    }
}