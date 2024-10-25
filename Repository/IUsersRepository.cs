using LibrarySystemWeb.Models;

namespace LibrarySystemWeb.Repository
{
    public interface IUsersRepository
    {
        Task<Users?> VerifyAuthentication( string email, string password );
        Task<Users?> GetByEmail( string email );
    }
}
