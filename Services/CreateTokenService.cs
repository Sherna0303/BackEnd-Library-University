using LibrarySystemWeb.Interfaces;
using LibrarySystemWeb.Models;
using LibrarySystemWeb.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibrarySystemWeb.Services
{
    public class CreateTokenService : ICreateTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsersRepository _userRepository;

        public CreateTokenService( IConfiguration configuration, IUsersRepository userRepository )
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<string> GenerateToken( Users user )
        {
            var userData = await _userRepository.GetByEmail( user.Email );

            var claims = new[]
            {
                new Claim("Id", userData.Id.ToString()),
                new Claim(ClaimTypes.Role, userData.Role.ToString()),
            };

            var key = new SymmetricSecurityKey( Encoding.UTF8.GetBytes( _configuration.GetSection( "JWT:Key" ).Value ) );
            var credencial = new SigningCredentials( key, SecurityAlgorithms.HmacSha512Signature );

            var securityToken = new JwtSecurityToken(
                                claims: claims,
                                expires: DateTime.Now.AddMinutes( 60 ),
                                signingCredentials: credencial
                                );

            string token = new JwtSecurityTokenHandler().WriteToken( securityToken );

            return token;
        }
    }
}
