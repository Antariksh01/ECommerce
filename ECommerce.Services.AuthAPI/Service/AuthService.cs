using ECommerce.Services.AuthAPI.Data;
using ECommerce.Services.AuthAPI.Models;
using ECommerce.Services.AuthAPI.Models.Dto;
using ECommerce.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(AppDbContext appDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _appDbContext.ApplicationUser.FirstOrDefault(x => x.UserName.ToLower() == loginRequestDto.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            if(user == null || isValid == false)
            {
                return new LoginResponseDto()
                {
                    user=null,
                    Token=""
                };
            }
            UserDto userDto = new()
            {
                Name = user.Name,
                Email = user.Email,
                ID = user.Id,
                PhoneNumber = user.PhoneNumber
            };

            return new LoginResponseDto()
            {
                user = userDto,
                Token = ""
            };

        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new ApplicationUser()
            {

                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                PhoneNumber = registrationRequestDto.PhoneNumber,
                Name = registrationRequestDto.Name
            };
            try
            {

                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _appDbContext.ApplicationUser.First(x => x.UserName == registrationRequestDto.Email);
                    UserDto userDto = new()
                    {
                        Name = userToReturn.Name,
                        Email = userToReturn.Email,
                        PhoneNumber = userToReturn.PhoneNumber,
                        ID = userToReturn.Id
                    };

                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex) { }

            return "Error Encountered";
        }
    }
}
