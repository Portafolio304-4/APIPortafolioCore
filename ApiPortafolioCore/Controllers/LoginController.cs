using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace ApiPortafolioCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("auth")]
        public JsonResult Auth([FromBody]Login login)
        {
            ResponseMenssage response;

            Usuario usuario = new Usuario();
            usuario.Username = login.Username;
            UsuarioModel usuarioQuery = new UsuarioModel(usuario);
            if (usuarioQuery.ReadByUsername())
            {
                login.Contrasena = Seguridad.Encriptar(login.Contrasena);

                if (login.Contrasena.Equals(usuarioQuery.Usuario.Contrasena))
                {
                    response = new ResponseMenssage("success", usuarioQuery.Usuario);
                    return new JsonResult(response);
                }

            }
            response = new ResponseMenssage("error", "usuario o contraseña invalidos");
            return new JsonResult(response);
        }
    }
}