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
    public class UsuarioController : ControllerBase
    {
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
    }
}