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
    public class TipoOrganizacionController : ControllerBase
    {
        // GET api/tipoorganizacion
        [HttpGet]
        public JsonResult Get()
        {
            TipoOrganizacionModel tipoOrganizacionQuery = new TipoOrganizacionModel(new TipoOrganizacion());

            ResponseMenssage response = new ResponseMenssage("success", tipoOrganizacionQuery.GetTipos());
            return new JsonResult(response);
        }


        // GET api/tipoorganizacion/1
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            TipoOrganizacion tipo_organizacion = new TipoOrganizacion
            {
                Id = id
            };
            TipoOrganizacionModel tipoOrganizacionQuery = new TipoOrganizacionModel(tipo_organizacion);


            if (tipoOrganizacionQuery.ReadById())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoOrganizacionQuery.Tipo_organizacion);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "tipo_organizacion no encontrada");
                return new JsonResult(response);
            }
        }

        // POST api/tipoorganizacion
        [HttpPost]
        public JsonResult Post([FromBody]TipoOrganizacion tipo_organizacion)
        {
            TipoOrganizacionModel tipoOrganizacionQuery = new TipoOrganizacionModel(tipo_organizacion);

            if (tipoOrganizacionQuery.Create())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoOrganizacionQuery.Tipo_organizacion);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al crear region");
                return new JsonResult(response);
            }
        }

        // PUT api/tipoorganizacion/1
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]TipoOrganizacion tipo_organizacion)
        {
            TipoOrganizacionModel tipoOrganizacionQuery = new TipoOrganizacionModel(tipo_organizacion);
            tipoOrganizacionQuery.Tipo_organizacion.Id = id;

            if (tipoOrganizacionQuery.Update())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoOrganizacionQuery.Tipo_organizacion);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al modificar tipo_organizacion");
                return new JsonResult(response);
            }
        }

        // DELETE api/tipoorganizacion/1
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            TipoOrganizacionModel tipoOrganizacionQuery = new TipoOrganizacionModel(new TipoOrganizacion());
            tipoOrganizacionQuery.Tipo_organizacion.Id = id;

            if (tipoOrganizacionQuery.Delete())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoOrganizacionQuery.Tipo_organizacion);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al eliminar tipo_organizacion");
                return new JsonResult(response);
            }
        }
    }
}