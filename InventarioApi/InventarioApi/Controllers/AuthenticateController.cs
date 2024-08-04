using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entidades;
using Domain.Interfaces;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace InventarioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateRepository _authenticateRepository;
        private readonly string secretKey;
        private readonly IEncryptMD5 _encryptMD5;

        // Constructor: Inyecta las dependencias necesarias
        public AuthenticateController(IConfiguration config, IAuthenticateRepository authenticateRepository, IEncryptMD5 encryptMD5)
        {
            _authenticateRepository = authenticateRepository;
            secretKey = config.GetSection("settings").GetSection("sercretkey").ToString();
            _encryptMD5 = encryptMD5;
        }

        // Acción para autenticar al usuario
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] User Users)
        {
            try
            {
                // Encripta la contraseña del usuario
                var encryptedPassword = await _encryptMD5.EncryptMD5Async(Users.Password);

                // Valida las credenciales del usuario
                var (isValid, userId, userName) = await _authenticateRepository.LoginValidateAsync(Users.Email, encryptedPassword);

                if (isValid)
                {
                    // Genera un token JWT si las credenciales son válidas
                    var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                    var claims = new ClaimsIdentity();
                    claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, Users.Email));

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddMinutes(20),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
                    string tokenCreated = tokenHandler.WriteToken(tokenConfig);

                    // Devuelve el token y detalles del usuario autenticado
                    var loginOk = Ok(new
                    {
                        Token = tokenCreated,
                        UserId = userId,
                        UserName = userName
                    });

                    return loginOk;
                }
                else
                {
                    // Devuelve un error si las credenciales son inválidas
                    return StatusCode(StatusCodes.Status400BadRequest, "Credenciales inválidas");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error en el servidor: {ex.Message}");
            }
        }
    }
}
