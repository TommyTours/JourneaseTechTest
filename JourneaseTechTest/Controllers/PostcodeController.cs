using System.Collections.Generic;
using JourneaseTechTest.AppCode;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JourneaseTechTest.Controllers
{
    [Route("api/[controller]")]
    public class PostcodeController : Controller
    {
        private IMapProvider provider;

        //If I had more time I would work out how to de-couple this;
        public PostcodeController(IMapProvider mapProvider)
        {
            provider = mapProvider;
        }

        [HttpGet("[controller]/[action]/{postcode}", Name = "Postcode")]
        public string Exists(string postcode)
        {
            var jsonString = JsonConvert.SerializeObject(provider.postCodeExists(postcode));
            return jsonString;
        }

        [HttpGet("{postcode}", Name = "PostCode")]
        [Route("api/[controller]/[getcoordinates]")]
        public string GetCoordinates(string postcode)
        {
            Coordinates coords = provider.GetCoordinates(postcode);

            var jsonString = JsonConvert.SerializeObject(coords);

            return jsonString;
        }
    }
}
