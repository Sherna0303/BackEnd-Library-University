namespace LibrarySystemWeb.Models.Dtos
{
    public class UserRegisterDto
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Name { get; set; } = default!;
    }
}
