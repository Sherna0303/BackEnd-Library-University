using LibrarySystemWeb.Interfaces;
using LibrarySystemWeb.Models;
using LibrarySystemWeb.Models.Dtos;
using LibrarySystemWeb.Repository;
using System.Security.Cryptography;
using System.Text;

namespace LibrarySystemWeb.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IUsersRepository _userRepository;
        private readonly ApplicationDbContext _dbContext;

        public RegisterService( IUsersRepository userRepository, ApplicationDbContext dbContext )
        {
            _userRepository = userRepository;
            _dbContext = dbContext;
        }

        public async Task<Users?> RegisterUser( UserRegisterDto user )
        {
            bool AlreadyRegistered = await _userRepository.EmailAlreadyRegistered( user.Email );

            if ( AlreadyRegistered )
            {
                return null;
            }


            var userDb = new Users()
            {
                Email = user.Email,
                Password = HashPassword( user.Password ),
                Role = user.Role
            };

            await _userRepository.AddUser( userDb );

            if ( !await _dbContext.SaveAsync() )
            {
                return null;
            }

            return userDb;
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
