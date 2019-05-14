using System.Collections.Generic;
using CIKataBackEnd.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CIKataBackEnd.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {

        // GET api/values/
        [HttpGet]
        public JsonResult Get()
        {
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            var returnString = string.Empty;

            BusinessLogicService bls = new BusinessLogicService();

            returnString = bls.MakeUpValue();

            return new JsonResult(returnString);
        }
    }
}