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
    public class AlumnoController : ControllerBase
    {
        // GET api/alumno
        [HttpGet]
        public JsonResult Get()
        {
            AlumnoModel alumnoQuery = new AlumnoModel(new Alumno());

            ResponseMenssage response = new ResponseMenssage("success", alumnoQuery.GetAlumnos());
            return new JsonResult(response);
        }


        // GET api/alumno/1
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Alumno alumno = new Alumno
            {
                Rut = id
            };
            AlumnoModel alumnoQuery = new AlumnoModel(alumno);


            if (alumnoQuery.ReadById())
            {
                ResponseMenssage response = new ResponseMenssage("success", alumnoQuery.Alumno);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "alumno no encontrada");
                return new JsonResult(response);
            }
        }

        // PUT api/alumno/1
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]Alumno alumno)
        {
            AlumnoModel alumnoQuery = new AlumnoModel(alumno);
            alumnoQuery.Alumno.Rut = id;

            if (alumnoQuery.Update())
            {
                ResponseMenssage response = new ResponseMenssage("success", alumnoQuery.Alumno);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al modificar");
                return new JsonResult(response);
            }
        }

        // DELETE api/alumno/1
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            AlumnoModel alumnoQuery = new AlumnoModel(new Alumno());
            alumnoQuery.Alumno.Rut = id;

            if (alumnoQuery.Delete())
            {
                ResponseMenssage response = new ResponseMenssage("success", alumnoQuery.Alumno);
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