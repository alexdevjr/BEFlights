using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEFlights.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        // GET: api/<DefaultController>
        [HttpGet]
        public string Get()
        {
            return "Aplicacion corriendo...";
        }
    }
}
