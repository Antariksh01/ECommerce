namespace ECommerce.Web.Models
{
    public class LoginResponseDto
    {
        public UserDto user { get; set; }
        public string Token { get; set; }
    }
}
