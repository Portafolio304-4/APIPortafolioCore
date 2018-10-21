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
    public class ActividadController : ControllerBase
    {
        // GET api/actividad
        [HttpGet]
        public JsonResult Get()
        {
            ActividadModel actividadQuery = new ActividadModel(new Actividad());

            ResponseMenssage response = new ResponseMenssage("success", actividadQuery.GetActividads());
            return new JsonResult(response);
        }


        // GET api/actividad/1
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Actividad actividad = new Actividad
            {
                Id = id
            };
            ActividadModel actividadQuery = new ActividadModel(actividad);


            if (actividadQuery.ReadById())
            {
                ResponseMenssage response = new ResponseMenssage("success", actividadQuery.Actividad);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "actividad no encontrada");
                return new JsonResult(response);
            }
        }

        [HttpPost]
        public JsonResult Post([FromBody]Actividad actividad)
        {
            ActividadModel ActividadeQuery = new ActividadModel(actividad);

            if (ActividadeQuery.Create())
            {
                ResponseMenssage response = new ResponseMenssage("success", ActividadeQuery.Actividad);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al crear");
                return new JsonResult(response);
            }
        }

        // PUT api/actividad/1
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]Actividad actividad)
        {
            ActividadModel actividadQuery = new ActividadModel(actividad);
            actividadQuery.Actividad.Id = id;

            if (actividadQuery.Update())
            {
                ResponseMenssage response = new ResponseMenssage("success", actividadQuery.Actividad);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al modificar");
                return new JsonResult(response);
            }
        }

        // DELETE api/actividad/1
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            ActividadModel actividadQuery = new ActividadModel(new Actividad());
            actividadQuery.Actividad.Id = id;

            if (actividadQuery.Delete())
            {
                ResponseMenssage response = new ResponseMenssage("success", actividadQuery.Actividad);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al eliminar");
                return new JsonResult(response);
            }
        }
    }
}