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
    public class TipoUsuarioController : ControllerBase
    {
        // GET api/tipousuario
        [HttpGet]
        public JsonResult Get()
        {
            TipoUsuarioModel tipoUsuarioQuery = new TipoUsuarioModel(new TipoUsuario());

            ResponseMenssage response = new ResponseMenssage("success", tipoUsuarioQuery.GetTipos());
            return new JsonResult(response);
        }


        // GET api/tipousuario/1
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            TipoUsuario tipo_usuario = new TipoUsuario
            {
                Id = id
            };
            TipoUsuarioModel tipoUsuarioQuery = new TipoUsuarioModel(tipo_usuario);


            if (tipoUsuarioQuery.ReadById())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoUsuarioQuery.Tipo_usuario);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "tipo_usuario no encontrada");
                return new JsonResult(response);
            }
        }

        // POST api/region
        [HttpPost]
        public JsonResult Post([FromBody]TipoUsuario tipo_usuario)
        {
            TipoUsuarioModel tipoUsuarioQuery = new TipoUsuarioModel(tipo_usuario);

            if (tipoUsuarioQuery.Create())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoUsuarioQuery.Tipo_usuario);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al crear region");
                return new JsonResult(response);
            }
        }

        // PUT api/tipousuario/1
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]TipoUsuario tipo_usuario)
        {
            TipoUsuarioModel tipoUsuarioQuery = new TipoUsuarioModel(tipo_usuario);
            tipoUsuarioQuery.Tipo_usuario.Id = id;

            if (tipoUsuarioQuery.Update())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoUsuarioQuery.Tipo_usuario);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al modificar tipo_usuario");
                return new JsonResult(response);
            }
        }

        // DELETE api/tipousuario/1
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            TipoUsuarioModel tipoUsuarioQuery = new TipoUsuarioModel(new TipoUsuario());
            tipoUsuarioQuery.Tipo_usuario.Id = id;

            if (tipoUsuarioQuery.Delete())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoUsuarioQuery.Tipo_usuario);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al eliminar tipo_usuario");
                return new JsonResult(response);
            }
        }
    }
}