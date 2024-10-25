using LibrarySystemWeb.Models;
using LibrarySystemWeb.Models.Dtos;

namespace LibrarySystemWeb.Interfaces
{
    public interface IRegisterService
    {
        Task<Users?> RegisterUser( UserRegisterDto user );
    }
}
