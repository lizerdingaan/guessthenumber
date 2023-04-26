using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace GameWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Home : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World!");
        }

        [HttpPost]
        public IActionResult Post(JObject payload)
        {
            return Ok(payload);
        }
    }
}
