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
    public class TipoTransporteController : ControllerBase
    {
        // GET api/tipotransporte
        [HttpGet]
        public JsonResult Get()
        {
            TipoTransporteModel tipoTransporteQuery = new TipoTransporteModel(new TipoTransporte());

            ResponseMenssage response = new ResponseMenssage("success", tipoTransporteQuery.GetTipos());
            return new JsonResult(response);
        }


        // GET api/tipotransporte/1
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            TipoTransporte tipo_transporte = new TipoTransporte
            {
                Id = id
            };
            TipoTransporteModel tipoTransporteQuery = new TipoTransporteModel(tipo_transporte);


            if (tipoTransporteQuery.ReadById())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoTransporteQuery.Tipo_transporte);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "tipo_transporte no encontrada");
                return new JsonResult(response);
            }
        }

        // POST api/region
        [HttpPost]
        public JsonResult Post([FromBody]TipoTransporte tipo_transporte)
        {
            TipoTransporteModel tipoTransporteQuery = new TipoTransporteModel(tipo_transporte);

            if (tipoTransporteQuery.Create())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoTransporteQuery.Tipo_transporte);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al crear region");
                return new JsonResult(response);
            }
        }

        // PUT api/tipotransporte/1
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]TipoTransporte tipo_transporte)
        {
            TipoTransporteModel tipoTransporteQuery = new TipoTransporteModel(tipo_transporte);
            tipoTransporteQuery.Tipo_transporte.Id = id;

            if (tipoTransporteQuery.Update())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoTransporteQuery.Tipo_transporte);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al modificar tipo_transporte");
                return new JsonResult(response);
            }
        }

        // DELETE api/tipotransporte/1
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            TipoTransporteModel tipoTransporteQuery = new TipoTransporteModel(new TipoTransporte());
            tipoTransporteQuery.Tipo_transporte.Id = id;

            if (tipoTransporteQuery.Delete())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoTransporteQuery.Tipo_transporte);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al eliminar tipo_transporte");
                return new JsonResult(response);
            }
        }
    }
}