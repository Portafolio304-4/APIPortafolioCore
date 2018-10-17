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
    public class CursoController : ControllerBase
    {
        // GET api/curso
        [HttpGet]
        public JsonResult Get()
        {
            CursoModel cursoQuery = new CursoModel(new Curso());

            ResponseMenssage response = new ResponseMenssage("success", cursoQuery.GetCursos());
            return new JsonResult(response);
        }


        // GET api/curso/1
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Curso curso = new Curso
            {
                Id = id
            };
            CursoModel cursoQuery = new CursoModel(curso);


            if (cursoQuery.ReadById())
            {
                ResponseMenssage response = new ResponseMenssage("success", cursoQuery.Curso);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "curso no encontrada");
                return new JsonResult(response);
            }
        }

        // PUT api/curso/1
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]Curso curso)
        {
            CursoModel cursoQuery = new CursoModel(curso);
            cursoQuery.Curso.Id = id;

            if (cursoQuery.Update())
            {
                ResponseMenssage response = new ResponseMenssage("success", cursoQuery.Curso);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al modificar");
                return new JsonResult(response);
            }
        }

        // DELETE api/curso/1
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            CursoModel cursoQuery = new CursoModel(new Curso());
            cursoQuery.Curso.Id = id;

            if (cursoQuery.Delete())
            {
                ResponseMenssage response = new ResponseMenssage("success", cursoQuery.Curso);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al eliminar");
                return new JsonResult(response);
            }
        }

        // GET api/curso/1/alumno
        [HttpGet("{id_curso}/alumno")]
        public JsonResult GetCursoes(int id_curso)
        {
            Alumno alumno = new Alumno();
            alumno.Id_curso = id_curso;
            AlumnoModel alumnoQuery = new AlumnoModel(alumno);

            ResponseMenssage response = new ResponseMenssage("success", alumnoQuery.GetAlumnosByCurso());
            return new JsonResult(response);

        }

        // POST api/curso/1/curso
        [HttpPost("{id_curso}/curso")]
        public JsonResult PostCurso(int id_curso, [FromBody]Alumno alumno)
        {
            alumno.Id_curso = id_curso;

            AlumnoModel alumnoQuery = new AlumnoModel(alumno);


            if (alumnoQuery.Create())
            {
                ResponseMenssage response = new ResponseMenssage("success", alumnoQuery.Alumno);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al crear curso");
                return new JsonResult(response);
            }

        }
    }
}