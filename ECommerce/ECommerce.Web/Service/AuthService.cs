using ECommerce.Web.Models;
using ECommerce.Web.Service.IService;
using ECommerce.Web.Utility;

namespace ECommerce.Web.Service
{
    public class AuthService : IAuthService
    {
        private IBaseService _baseService;
        public AuthService(IBaseService baseService)
        {

            _baseService = baseService;

        }
        public async Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto)
        {
            var data = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.POST,
                Data = registrationRequestDto,
                ApiUrl = SD.AuthAPIBase + "/api/auth/AssignRole"

            });

            return data;
        }

        public async Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto)
        {
            var data = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.POST,
                Data = loginRequestDto,
                ApiUrl = SD.AuthAPIBase + "/api/auth/login"

            });

            return data;
        }

        public async Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto)
        {
            var data = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.POST,
                Data = registrationRequestDto,
                ApiUrl = SD.AuthAPIBase + "/api/auth/register"

            });

            return data;
        }
    }
}
