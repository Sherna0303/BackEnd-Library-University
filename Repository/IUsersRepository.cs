using LibrarySystemWeb.Models;

namespace LibrarySystemWeb.Repository
{
    public interface IUsersRepository
    {
        Task<User?> VerifyAuthentication( string email, string password );
        Task<User?> GetByEmail( string email );
        Task<bool> EmailAlreadyRegistered( string email );
        Task<User?> AddUser( User user );
    }
}
