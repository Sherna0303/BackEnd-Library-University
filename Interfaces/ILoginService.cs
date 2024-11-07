using LibrarySystemWeb.Models;
using LibrarySystemWeb.Models.Dtos;

namespace LibrarySystemWeb.Interfaces
{
    public interface ILoginService
    {
        Task<User> GetUser( UserDto user );
    }
}