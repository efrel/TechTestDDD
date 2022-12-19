using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechTestDDD.Api.Controllers
{
    [Route("api/[controller]")]
    public class VehicleController : ApiController
    {
        [HttpGet]
        public IActionResult ListVehicles()
        {
            return Ok(Array.Empty<string>());  
        }
    }
}
