using apiProgramacion06.Modelos;
using Entidades.EntidadesSeguridad;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace apiProgramacion06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly ISeguridadLN gObjSegLN;
        private readonly string lfraseSecreta;

        public AutenticacionController(IConfiguration pConfig)
        {
            gObjSegLN = new SeguridadLN(pConfig.GetConnectionString("SEGCnx"));
            lfraseSecreta = pConfig.GetSection("LlaveToken:frase").ToString();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult validarUsuario([FromBody] Usuario pUsuario)
        {
            var usuarioExiste = gObjSegLN.obtenerUsuario(pUsuario.usuario);
            if(usuarioExiste != null)
            {
                if (usuarioExiste.TcContrasena == pUsuario.contrasena)
                {
                    var llaveBytes = Encoding.ASCII.GetBytes(lfraseSecreta);
                    var dato = new ClaimsIdentity();
                    dato.AddClaim(new Claim(ClaimTypes.NameIdentifier, pUsuario.usuario));
                    var descToken = new SecurityTokenDescriptor
                    {
                        Subject = dato,
                        Expires = DateTime.UtcNow.AddMinutes(5),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llaveBytes),
                        SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenConfig = tokenHandler.CreateToken(descToken);
                    string tokenCreado = tokenHandler.WriteToken(tokenConfig);
                    return StatusCode(StatusCodes.Status200OK, new { token = tokenCreado });
                }
                else
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            }
        }

        [HttpGet]
        [Route("[action]")]
        public List<TusrPerfilesXUsuario> obtenerPerfilesXUsuario(string pLogin)
        {
            return gObjSegLN.obtenerPerfilesXUsuario(pLogin);
        }

    }
}
