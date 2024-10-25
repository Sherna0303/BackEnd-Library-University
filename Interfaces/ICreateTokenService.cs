using LibrarySystemWeb.Models.Dtos;

namespace LibrarySystemWeb.Interfaces
{
    public interface ICreateTokenService
    {
        Task<string> GenerateToken( UserDto user );
    }
}
