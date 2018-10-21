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
    public class ServicioTuristicoController : ControllerBase
    {

        // GET api/servicioturistico
        [HttpGet]
        public JsonResult Get()
        {
            ServicioTuristicoModel servicio_turisticoQuery = new ServicioTuristicoModel(new ServicioTuristico());

            ResponseMenssage response = new ResponseMenssage("success", servicio_turisticoQuery.GetServicioTuristicos());
            return new JsonResult(response);
        }


        // GET api/servicioturistico/1
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            ServicioTuristico servicio_turistico = new ServicioTuristico
            {
                Id = id
            };
            ServicioTuristicoModel servicio_turisticoQuery = new ServicioTuristicoModel(servicio_turistico);


            if (servicio_turisticoQuery.ReadById())
            {
                ResponseMenssage response = new ResponseMenssage("success", servicio_turisticoQuery.Servicio_turistico);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "servicio_turistico no encontrada");
                return new JsonResult(response);
            }
        }

        // POST api/servicioturistico
        [HttpPost]
        public JsonResult Post([FromBody]ServicioTuristico servicio_turistico)
        {
            ServicioTuristicoModel ServicioTuristicoeQuery = new ServicioTuristicoModel(servicio_turistico);

            if (ServicioTuristicoeQuery.Create())
            {
                ResponseMenssage response = new ResponseMenssage("success", ServicioTuristicoeQuery.Servicio_turistico);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al crear");
                return new JsonResult(response);
            }
        }

        // PUT api/servicioturistico/1
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]ServicioTuristico servicio_turistico)
        {
            ServicioTuristicoModel servicio_turisticoQuery = new ServicioTuristicoModel(servicio_turistico);
            servicio_turisticoQuery.Servicio_turistico.Id = id;

            if (servicio_turisticoQuery.Update())
            {
                ResponseMenssage response = new ResponseMenssage("success", servicio_turisticoQuery.Servicio_turistico);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al modificar");
                return new JsonResult(response);
            }
        }

        // DELETE api/servicioturistico/1
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            ServicioTuristicoModel servicio_turisticoQuery = new ServicioTuristicoModel(new ServicioTuristico());
            servicio_turisticoQuery.Servicio_turistico.Id = id;

            if (servicio_turisticoQuery.Delete())
            {
                ResponseMenssage response = new ResponseMenssage("success", servicio_turisticoQuery.Servicio_turistico);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al eliminar");
                return new JsonResult(response);
            }
        }

        // POST api/servicioturistico
        [HttpPost("{id}/detalle")]
        public JsonResult PostDetail([FromBody]STDetalle st_detalle)
        {
            STDetalleModel STDetalleModelQuery = new STDetalleModel(st_detalle);

            if (STDetalleModelQuery.Create())
            {
                ResponseMenssage response = new ResponseMenssage("success", STDetalleModelQuery.STDetalle);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al crear");
                return new JsonResult(response);
            }
        }
    }
        
}