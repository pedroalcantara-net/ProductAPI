using Microsoft.AspNetCore.Mvc;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("")]
        public IActionResult SignUp()
        {
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult SignIn()
        {
            return Ok();
        }
    }
}
