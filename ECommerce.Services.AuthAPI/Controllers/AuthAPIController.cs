using ECommerce.Services.AuthAPI.Models.Dto;
using ECommerce.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ECommerce.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ResponseDto _responseDto;

        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
                _responseDto = new ResponseDto();
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegistrationRequestDto registrationRequestDto) {

            var errorMessage = await _authService.Register(registrationRequestDto);
            if (errorMessage != null)
            {
                _responseDto.Success = false;
                _responseDto.Message = errorMessage;
                return BadRequest(_responseDto);
            }

            return Ok(_responseDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto) {

            var result = await _authService.Login(loginRequestDto);
            if (result.user == null)
            {
                _responseDto.Success = false;
                _responseDto.Message = "username or password is incorrect";
                return BadRequest(_responseDto);
            }
            _responseDto.Response = result;
            return Ok(_responseDto);
        }
    }
}
