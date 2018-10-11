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
    public class TipoActividadController : ControllerBase
    {
        // GET api/tipoactividad
        [HttpGet]
        public JsonResult Get()
        {
            TipoActividadModel tipoActividadQuery = new TipoActividadModel(new TipoActividad());

            ResponseMenssage response = new ResponseMenssage("success", tipoActividadQuery.GetTipos());
            return new JsonResult(response);
        }


        // GET api/tipoactividad/1
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            TipoActividad tipo_actividad = new TipoActividad
            {
                Id = id
            };
            TipoActividadModel tipoActividadQuery = new TipoActividadModel(tipo_actividad);


            if (tipoActividadQuery.ReadById())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoActividadQuery.Tipo_actividad);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "tipo_actividad no encontrada");
                return new JsonResult(response);
            }
        }

        // POST api/region
        [HttpPost]
        public JsonResult Post([FromBody]TipoActividad tipo_actividad)
        {
            TipoActividadModel tipoActividadQuery = new TipoActividadModel(tipo_actividad);

            if (tipoActividadQuery.Create())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoActividadQuery.Tipo_actividad);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al crear region");
                return new JsonResult(response);
            }
        }

        // PUT api/tipoactividad/1
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]TipoActividad tipo_actividad)
        {
            TipoActividadModel tipoActividadQuery = new TipoActividadModel(tipo_actividad);
            tipoActividadQuery.Tipo_actividad.Id = id;

            if (tipoActividadQuery.Update())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoActividadQuery.Tipo_actividad);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al modificar tipo_actividad");
                return new JsonResult(response);
            }
        }

        // DELETE api/tipoactividad/1
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            TipoActividadModel tipoActividadQuery = new TipoActividadModel(new TipoActividad());
            tipoActividadQuery.Tipo_actividad.Id = id;

            if (tipoActividadQuery.Delete())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoActividadQuery.Tipo_actividad);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al eliminar tipo_actividad");
                return new JsonResult(response);
            }
        }
    }
}