using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyStore_backend.Models.DTO;

namespace MyStore_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;


        public AuthController(UserManager<IdentityUser> userManager)
        {
            this._userManager = userManager;
        }



        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]  RegisterRequestDTO registerRequestDTO)
        {
            var user = new IdentityUser
            {
                UserName = registerRequestDTO.Email,
                Email = registerRequestDTO.Email
            };
            var userRegistrationResult = await _userManager.CreateAsync(user,registerRequestDTO.Password);

            if (userRegistrationResult.Succeeded)
            {
                return Ok(new { Message = "User registered successfully" });
            }
            return BadRequest(new { Message = "Something is wrong" });
            
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(loginRequestDTO.Email);

            if (user != null) { 

            var loginResult = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
                if (loginResult)
                {
                    //issure JWT token

                    return Ok(new {Message="Login succeeded"});
                }
            }
            
            return BadRequest(new { Message = "Wrong password or username" });
        }
    }
}
