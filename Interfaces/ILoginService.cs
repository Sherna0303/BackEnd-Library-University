using LibrarySystemWeb.Models;

namespace LibrarySystemWeb.Interfaces
{
    public interface ILoginService
    {
        Task<Users> GetUser( Users user );
    }
}