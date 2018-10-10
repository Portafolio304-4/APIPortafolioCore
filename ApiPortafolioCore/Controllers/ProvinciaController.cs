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
    public class ProvinciaController : ControllerBase
    {
        // GET api/provincia
        [HttpGet]
        public JsonResult Get()
        {
            ProvinciaModel provinciaQuery = new ProvinciaModel(new Provincia());

            ResponseMenssage response = new ResponseMenssage("success", provinciaQuery.GetProvincias());
            return new JsonResult(response);
        }


        // GET api/provincia/1
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Provincia provincia = new Provincia
            {
                Id = id
            };
            ProvinciaModel provinciaQuery = new ProvinciaModel(provincia);


            if (provinciaQuery.ReadById())
            {
                ResponseMenssage response = new ResponseMenssage("success", provinciaQuery.Provincia);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "region no encontrada");
                return new JsonResult(response);
            }
        }

        // PUT api/provincia/1
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]Provincia provincia)
        {
            ProvinciaModel provinciaQuery = new ProvinciaModel(provincia);
            provinciaQuery.Provincia.Id = id;

            if (provinciaQuery.Update())
            {
                ResponseMenssage response = new ResponseMenssage("success", provinciaQuery.Provincia);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al modificar");
                return new JsonResult(response);
            }
        }

        // DELETE api/provincia/1
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            ProvinciaModel provinciaQuery = new ProvinciaModel(new Provincia());
            provinciaQuery.Provincia.Id = id;

            if (provinciaQuery.Delete())
            {
                ResponseMenssage response = new ResponseMenssage("success", provinciaQuery.Provincia);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al eliminar");
                return new JsonResult(response);
            }
        }

        // GET api/provincia/1/comuna
        [HttpGet("{id_provincia}/comuna")]
        public JsonResult GetProvincias(int id_provincia)
        {
            Comuna comuna = new Comuna();
            comuna.Id_provincia = id_provincia;
            ComunaModel comunaQuery = new ComunaModel(comuna);

            ResponseMenssage response = new ResponseMenssage("success", comunaQuery.GetComunasByProvincia());
            return new JsonResult(response);

        }

        // POST api/provincia/1/comuna
        [HttpPost("{id_provincia}/comuna")]
        public JsonResult PostProvincia(int id_provincia, [FromBody]Comuna comuna)
        {
            comuna.Id_provincia = id_provincia;

            ComunaModel comunaQuery = new ComunaModel(comuna);


            if (comunaQuery.Create())
            {
                ResponseMenssage response = new ResponseMenssage("success", comunaQuery.Comuna);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al crear comuna");
                return new JsonResult(response);
            }

        }
    }
}
