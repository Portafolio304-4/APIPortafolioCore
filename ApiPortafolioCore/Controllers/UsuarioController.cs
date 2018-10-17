using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model;

namespace ApiPortafolioCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        public readonly IConfiguration _configuration;
        // endpoint o punto de salida

        // GET api/usuario -> va a traer todos los usuarios
        [HttpGet]
        public JsonResult Get()
        {
            UsuarioModel usuarioQuery = new UsuarioModel(new Usuario());
            ResponseMenssage response = new ResponseMenssage("success", usuarioQuery.GetUsuarios());

            return new JsonResult(response);
        }

        // GET api/usuario/1 -> va a traer usuario por id
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Usuario usuario = new Usuario();
            usuario.Id = id;

            UsuarioModel usuarioQuery = new UsuarioModel(usuario);

            if (usuarioQuery.ReadById())
            {
                ResponseMenssage response = new ResponseMenssage("success", usuarioQuery.Usuario);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "no se encontro al usuario");
                return new JsonResult(response);
            }
        }

        // GET api/usuario/auth -> login
        [HttpGet("auth")]
        public JsonResult Auth(string username, string contrasena)
        {
            Usuario usuario = new Usuario();
            usuario.Username = username;
            usuario.Contrasena = contrasena;
            UsuarioModel usuarioQuery = new UsuarioModel(usuario);
            if (usuarioQuery.ReadByUsername())
            {
                object token = BuildToken(usuarioQuery.Usuario);
                return new JsonResult(token);
            }
            
            return new JsonResult("autentificacion");
        }

        // POST api/usuario -> insertar nuevo usuario
        [HttpPost]
        public JsonResult Post([FromBody]Usuario usuario)
        {
            UsuarioModel usuarioQuery = new UsuarioModel(usuario);

            if (usuarioQuery.Create())
            {
                ResponseMenssage response = new ResponseMenssage("success", usuarioQuery.Usuario);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "no se pudo crear el usuario");
                return new JsonResult(response);
            }
        }


        // PUT api/usuario/1 -> actualizar usuario por id
        [HttpPut("{id}")]
        public JsonResult Put(int id,[FromBody]Usuario usuario)
        {
            usuario.Id = id;
            UsuarioModel usuarioQuery = new UsuarioModel(usuario);

            if (usuarioQuery.Update())
            {
                ResponseMenssage response = new ResponseMenssage("success", usuarioQuery.Usuario);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "no se pudo actualizar el usuario");
                return new JsonResult(response);
            }
        }

        // DELETE api/usuario/1 -> eliminar usuario por id
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Usuario usuario = new Usuario();
            usuario.Id = id;

            UsuarioModel usuarioQuery = new UsuarioModel(usuario);

            if (usuarioQuery.Delete())
            {
                ResponseMenssage response = new ResponseMenssage("success", usuarioQuery.Usuario);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "no se pudo eliminar el usuario");
                return new JsonResult(response);
            }
        }

        private IActionResult BuildToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Username),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim("Tipo Usuario", usuario.Id_tipo_usuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["secret_key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer:"ontour.com",
                audience:"ontour.com",
                claims:claims,
                signingCredentials: creds
                );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
            
        }
    }
}