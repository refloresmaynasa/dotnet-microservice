namespace ProductService.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using ProductService.Models;
    using ProductService.Services;
    using System;
    using System.Threading.Tasks;

    [Route("api/auth")]
    [ApiController]
    public class UserController : ControllerBase
    {
        internal UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("register")] //<host>/api/auth/register
        public IActionResult Register([FromBody] UserModel userModel)
        {
            // Data Transfer Object containing username and password.
            // validate request
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                userService.RegisterUser(userModel);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserModel model)
        {
            UserModel user = await userService.AuthenticateAsync(model.Username, model.Password);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            return Ok(new { User = user.Username, Token = user.Token });
        }
    }
}
