using exe1.Dto;
using exe1.Interfaces;
using exe1.Models;
using exe1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exe1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase

    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }
        //Register
        [HttpPost("Register")]
        public async Task<UserResponseDto> Register(RegiterDto regiterDto)
        {
            return await service.Register(regiterDto);
        }
        //Login
        [HttpPost("Login")]
        [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginDto loginDto)
        {
            if (string.IsNullOrWhiteSpace(loginDto.UserName) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                return BadRequest(new { message = "UserName and password are required." });
            }

            var result = await service.AuthenticateAsync(loginDto.UserName, loginDto.Password);

            if (result == null)
            {
                return Unauthorized(new { message = "שם משתמש או סיסמא אינם נכונים!" });
            }

            return Ok(result);
        }
    }
}