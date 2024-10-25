using LibrarySystemWeb.Interfaces;
using LibrarySystemWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystemWeb.Controllers
{
    [ApiController]
    [Route( "[controller]" )]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly ICreateTokenService _createToken;

        public AuthController( ILoginService loginService, ICreateTokenService createToken )
        {
            _loginService = loginService;
            _createToken = createToken;
        }

        [HttpPost( "login" )]
        public async Task<IActionResult> Login( Users userDto )
        {

            var userAuth = await _loginService.GetUser( userDto );

            if ( userAuth is null )
            {
                return BadRequest( new { message = "Credenciales invalidas" } );
            }

            string jwtToken = await _createToken.GenerateToken( userDto );

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
