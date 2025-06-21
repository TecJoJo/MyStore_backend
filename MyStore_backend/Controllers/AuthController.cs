using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyStore_backend.Models.DTO;
using MyStore_backend.Repository;

namespace MyStore_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this._userManager = userManager;
            this._tokenRepository = tokenRepository;
        }



        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var user = new IdentityUser
            {
                UserName = registerRequestDTO.Email,
                Email = registerRequestDTO.Email
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registerRequestDTO.Password);

                if (result.Succeeded)
                {
                    var response = new ApiResponseDto<RegisterResponseDto>
                    {
                        Success = true,
                        Message = "User registered successfully",
                        Data = new RegisterResponseDto { Email = user.Email }
                    };
                    return Ok(response);
                }

                // Return identity errors
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new ApiResponseDto<object>
                {
                    Success = false,
                    Message = "User registration failed",
                    Errors = errors
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponseDto<object>
                {
                    Success = false,
                    Message = "An unexpected error occurred",
                    Errors = new[] { ex.Message }
                });
            }
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
                    var jwtToken = _tokenRepository.createJwtToken(user);
                    var resposne = new LoginResponseDTO
                    {
                        Message = "Login succeeded",
                        JwtToken = jwtToken,
                        Username = user.UserName

                    };
                    return Ok(resposne);
                }
            }
            
            

            return BadRequest(new { Message = "Wrong password or username" });
        }
    }
}
