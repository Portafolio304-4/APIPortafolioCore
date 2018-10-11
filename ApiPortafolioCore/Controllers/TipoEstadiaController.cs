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
    public class TipoEstadiaController : ControllerBase
    {
        // GET api/tipoestadia
        [HttpGet]
        public JsonResult Get()
        {
            TipoEstadiaModel tipoEstadiaQuery = new TipoEstadiaModel(new TipoEstadia());

            ResponseMenssage response = new ResponseMenssage("success", tipoEstadiaQuery.GetTipos());
            return new JsonResult(response);
        }


        // GET api/tipoestadia/1
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            TipoEstadia tipo_estadia = new TipoEstadia
            {
                Id = id
            };
            TipoEstadiaModel tipoEstadiaQuery = new TipoEstadiaModel(tipo_estadia);


            if (tipoEstadiaQuery.ReadById())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoEstadiaQuery.Tipo_estadia);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "tipo_estadia no encontrada");
                return new JsonResult(response);
            }
        }

        // POST api/region
        [HttpPost]
        public JsonResult Post([FromBody]TipoEstadia tipo_estadia)
        {
            TipoEstadiaModel tipoEstadiaQuery = new TipoEstadiaModel(tipo_estadia);

            if (tipoEstadiaQuery.Create())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoEstadiaQuery.Tipo_estadia);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al crear region");
                return new JsonResult(response);
            }
        }

        // PUT api/tipoestadia/1
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]TipoEstadia tipo_estadia)
        {
            TipoEstadiaModel tipoEstadiaQuery = new TipoEstadiaModel(tipo_estadia);
            tipoEstadiaQuery.Tipo_estadia.Id = id;

            if (tipoEstadiaQuery.Update())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoEstadiaQuery.Tipo_estadia);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al modificar tipo_estadia");
                return new JsonResult(response);
            }
        }

        // DELETE api/tipoestadia/1
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            TipoEstadiaModel tipoEstadiaQuery = new TipoEstadiaModel(new TipoEstadia());
            tipoEstadiaQuery.Tipo_estadia.Id = id;

            if (tipoEstadiaQuery.Delete())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoEstadiaQuery.Tipo_estadia);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al eliminar tipo_estadia");
                return new JsonResult(response);
            }
        }
    }
}