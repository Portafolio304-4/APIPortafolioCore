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
    public class OrganizacionController : ControllerBase
    {
        // GET api/organizacion
        [HttpGet]
        public JsonResult Get()
        {
            OrganizacionModel organizacionQuery = new OrganizacionModel(new Organizacion());

            ResponseMenssage response = new ResponseMenssage("success", organizacionQuery.GetOrganizaciones());
            return new JsonResult(response);
        }


        // GET api/organizacion/1
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Organizacion organizacion = new Organizacion
            {
                Id = id
            };
            OrganizacionModel organizacionQuery = new OrganizacionModel(organizacion);


            if (organizacionQuery.ReadById())
            {
                ResponseMenssage response = new ResponseMenssage("success", organizacionQuery.Organizacion);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "region no encontrada");
                return new JsonResult(response);
            }
        }

        // GET api/organizacion
        [HttpPost]
        public JsonResult Post([FromBody]Organizacion organizacion)
        {
            OrganizacionModel OrganizacioneQuery = new OrganizacionModel(organizacion);

            if (OrganizacioneQuery.Create())
            {
                ResponseMenssage response = new ResponseMenssage("success", OrganizacioneQuery.Organizacion);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al crear");
                return new JsonResult(response);
            }
        }

        // PUT api/organizacion/1
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]Organizacion organizacion)
        {
            OrganizacionModel organizacionQuery = new OrganizacionModel(organizacion);
            organizacionQuery.Organizacion.Id = id;

            if (organizacionQuery.Update())
            {
                ResponseMenssage response = new ResponseMenssage("success", organizacionQuery.Organizacion);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al modificar");
                return new JsonResult(response);
            }
        }

        // DELETE api/organizacion/1
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            OrganizacionModel organizacionQuery = new OrganizacionModel(new Organizacion());
            organizacionQuery.Organizacion.Id = id;

            if (organizacionQuery.Delete())
            {
                ResponseMenssage response = new ResponseMenssage("success", organizacionQuery.Organizacion);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al eliminar");
                return new JsonResult(response);
            }
        }

        // GET api/organizacion/1/curso
        [HttpGet("{id_organizacion}/curso")]
        public JsonResult GetOrganizaciones(int id_organizacion)
        {
            Curso curso = new Curso();
            curso.Id_organizacion = id_organizacion;
            CursoModel cursoQuery = new CursoModel(curso);

            ResponseMenssage response = new ResponseMenssage("success", cursoQuery.GetCursosByOrganizacion());
            return new JsonResult(response);

        }

        // POST api/organizacion/1/curso
        [HttpPost("{id_organizacion}/curso")]
        public JsonResult PostOrganizacion(int id_organizacion, [FromBody]Curso curso)
        {
            curso.Id_organizacion = id_organizacion;

            CursoModel cursoQuery = new CursoModel(curso);


            if (cursoQuery.Create())
            {
                ResponseMenssage response = new ResponseMenssage("success", cursoQuery.Curso);
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