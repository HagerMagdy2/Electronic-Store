using ElectronicStore.API.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicStore.API.Controllers
{
    [Route("error/{StatusCode}")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Error(int StatusCode)
        {
           return new ObjectResult(new ResponseAPI(StatusCode));

        }
    }
}
