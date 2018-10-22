using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPortafolioCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransporteController : ControllerBase
    {
        // GET api/transporte
        [HttpGet]
        public JsonResult Get()
        {
            TransporteModel transporteQuery = new TransporteModel(new Transporte());

            ResponseMenssage response = new ResponseMenssage("success", transporteQuery.GetTransportes());
            return new JsonResult(response);
        }


        // GET api/transporte/1
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Transporte transporte = new Transporte
            {
                Rut = id
            };
            TransporteModel transporteQuery = new TransporteModel(transporte);


            if (transporteQuery.ReadById())
            {
                ResponseMenssage response = new ResponseMenssage("success", transporteQuery.Transporte);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "transporte no encontrada");
                return new JsonResult(response);
            }
        }

        // PUT api/transporte/1
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]Transporte transporte)
        {
            TransporteModel transporteQuery = new TransporteModel(transporte);
            transporteQuery.Transporte.Rut = id;

            if (transporteQuery.Update())
            {
                ResponseMenssage response = new ResponseMenssage("success", transporteQuery.Transporte);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al modificar");
                return new JsonResult(response);
            }
        }

        // DELETE api/transporte/1
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            TransporteModel transporteQuery = new TransporteModel(new Transporte());
            transporteQuery.Transporte.Rut = id;

            if (transporteQuery.Delete())
            {
                ResponseMenssage response = new ResponseMenssage("success", transporteQuery.Transporte);
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