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
    public class EstadiaController : ControllerBase
    {
        // GET api/estadia
        [HttpGet]
        public JsonResult Get()
        {
            EstadiaModel estadiaQuery = new EstadiaModel(new Estadia());

            ResponseMenssage response = new ResponseMenssage("success", estadiaQuery.GetEstadias());
            return new JsonResult(response);
        }


        // GET api/estadia/1
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Estadia estadia = new Estadia
            {
                Id = id
            };
            EstadiaModel estadiaQuery = new EstadiaModel(estadia);


            if (estadiaQuery.ReadById())
            {
                ResponseMenssage response = new ResponseMenssage("success", estadiaQuery.Estadia);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "estadia no encontrada");
                return new JsonResult(response);
            }
        }
        // GET api/estadia
        [HttpPost]
        public JsonResult Post([FromBody]Estadia estadia)
        {
            EstadiaModel EstadiaeQuery = new EstadiaModel(estadia);

            if (EstadiaeQuery.Create())
            {
                ResponseMenssage response = new ResponseMenssage("success", EstadiaeQuery.Estadia);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al crear");
                return new JsonResult(response);
            }
        }

        // PUT api/estadia/1
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]Estadia estadia)
        {
            EstadiaModel estadiaQuery = new EstadiaModel(estadia);
            estadiaQuery.Estadia.Id = id;

            if (estadiaQuery.Update())
            {
                ResponseMenssage response = new ResponseMenssage("success", estadiaQuery.Estadia);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al modificar");
                return new JsonResult(response);
            }
        }

        // DELETE api/estadia/1
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            EstadiaModel estadiaQuery = new EstadiaModel(new Estadia());
            estadiaQuery.Estadia.Id = id;

            if (estadiaQuery.Delete())
            {
                ResponseMenssage response = new ResponseMenssage("success", estadiaQuery.Estadia);
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