using LibrarySystemWeb.Interfaces;
using LibrarySystemWeb.Models.Dtos;
using LibrarySystemWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystemWeb.Controllers
{
    [ApiController]
    [Route( "[controller]" )]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;
        private readonly ICreateTokenService _createToken;

        public AuthController( ILoginService loginService, IRegisterService registerService, ICreateTokenService createToken )
        {
            _loginService = loginService;
            _registerService = registerService;
            _createToken = createToken;
        }

        [HttpPost( "login" )]
        public async Task<IActionResult> Login( UserDto userDto )
        {

            var userAuth = await _loginService.GetUser( userDto );

            if ( userAuth is null )
            {
                return BadRequest( new { message = "Credenciales invalidas" } );
            }

            string jwtToken = await _createToken.GenerateToken( userDto );

            return Ok( new { token = jwtToken } );
        }

        [HttpPost( "register" )]
        public async Task<IActionResult> Register( UserRegisterDto userRegisterDTO )
        {
            var user = await _registerService.RegisterUser( userRegisterDTO );

            if ( user is null )
            {
                return BadRequest( new { message = "Error" } );
            }

            string jwtToken = await _createToken.GenerateToken( new UserDto() { Email = user.Email, Password = user.Password } );

            return Ok( new { token = jwtToken } );
        }

        [HttpGet( "verifyToken" )]
        [Authorize]
        public IActionResult VerifyToken()
        {
            return Ok( new { verify = "OK" } );
        }
    }
}
