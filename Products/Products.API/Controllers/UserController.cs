using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Domain.ViewModel;
using Products.Service.Interface;

namespace Products.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _user;
        public UserController(IUserService user)
        {
            _user = user;
        }

        [HttpPost("signup")]
        public IActionResult SignUp(UserViewmodel user)
        {
            return Created("", _user.SignUp(user));
        }

        [HttpPost]
        public IActionResult SignIn(UserViewmodel user)
        {
            return Ok(_user.Login(user));
        }
    }
}
