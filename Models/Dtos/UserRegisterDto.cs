using LibrarySystemWeb.Models.Enum;

namespace LibrarySystemWeb.Models.Dtos
{
    public class UserRegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set; }
    }
}
