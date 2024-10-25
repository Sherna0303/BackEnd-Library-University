using LibrarySystemWeb.Interfaces;
using LibrarySystemWeb.Models;
using LibrarySystemWeb.Models.Dtos;
using LibrarySystemWeb.Repository;
using System.Security.Cryptography;
using System.Text;

namespace LibrarySystemWeb.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUsersRepository _userRepository;

        public LoginService( IUsersRepository userRepository )
        {
            _userRepository = userRepository;
        }

        public async Task<Users?> GetUser( UserDto user )
        {
            return await _userRepository.VerifyAuthentication( user.Email, HashPassword( user.Password ) );
        }
        
        private string HashPassword( string password )
        {
            using ( SHA256 sha256 = SHA256.Create() )
            {
                byte[] hashedBytes = sha256.ComputeHash( Encoding.UTF8.GetBytes( password ) );
                StringBuilder builder = new StringBuilder();
                foreach ( byte b in hashedBytes )
                {
                    builder.Append( b.ToString( "x2" ) );
                }
                return builder.ToString();
            }
        }
    }
}
