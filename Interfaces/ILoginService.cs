using LibrarySystemWeb.Models;
using LibrarySystemWeb.Models.Dtos;

namespace LibrarySystemWeb.Interfaces
{
    public interface ILoginService
    {
        Task<Users> GetUser( UserDto user );
    }
}