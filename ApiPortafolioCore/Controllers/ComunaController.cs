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
    public class ComunaController : ControllerBase
    {
        // GET api/comuna
        [HttpGet]
        public JsonResult Get()
        {
            ComunaModel comunaQuery = new ComunaModel(new Comuna());

            ResponseMenssage response = new ResponseMenssage("success", comunaQuery.GetComunas());
            return new JsonResult(response);
        }


        // GET api/comuna/1
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Comuna comuna = new Comuna
            {
                Id = id
            };
            ComunaModel comunaQuery = new ComunaModel(comuna);


            if (comunaQuery.ReadById())
            {
                ResponseMenssage response = new ResponseMenssage("success", comunaQuery.Comuna);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "comuna no encontrada");
                return new JsonResult(response);
            }
        }

        // PUT api/comuna/1
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]Comuna comuna)
        {
            ComunaModel comunaQuery = new ComunaModel(comuna);
            comunaQuery.Comuna.Id = id;

            if (comunaQuery.Update())
            {
                ResponseMenssage response = new ResponseMenssage("success", comunaQuery.Comuna);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al modificar comuna");
                return new JsonResult(response);
            }
        }

        // DELETE api/comuna/1
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            ComunaModel comunaQuery = new ComunaModel(new Comuna());
            comunaQuery.Comuna.Id = id;

            if (comunaQuery.Delete())
            {
                ResponseMenssage response = new ResponseMenssage("success", comunaQuery.Comuna);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al eliminar comuna");
                return new JsonResult(response);
            }
        }

    }
}