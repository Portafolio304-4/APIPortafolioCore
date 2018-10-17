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
    public class ApoderadoController : ControllerBase
    {
        // GET api/apoderado
        [HttpGet]
        public JsonResult Get()
        {
            ApoderadoModel apoderadoQuery = new ApoderadoModel(new Apoderado());

            ResponseMenssage response = new ResponseMenssage("success", apoderadoQuery.GetApoderados());
            return new JsonResult(response);
        }


        // GET api/apoderado/1
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Apoderado apoderado = new Apoderado
            {
                Rut = id
            };
            ApoderadoModel apoderadoQuery = new ApoderadoModel(apoderado);


            if (apoderadoQuery.ReadById())
            {
                ResponseMenssage response = new ResponseMenssage("success", apoderadoQuery.Apoderado);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "apoderado no encontrada");
                return new JsonResult(response);
            }
        }

        // PUT api/apoderado/1
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]Apoderado apoderado)
        {
            ApoderadoModel apoderadoQuery = new ApoderadoModel(apoderado);
            apoderadoQuery.Apoderado.Rut = id;

            if (apoderadoQuery.Update())
            {
                ResponseMenssage response = new ResponseMenssage("success", apoderadoQuery.Apoderado);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al modificar");
                return new JsonResult(response);
            }
        }

        // DELETE api/apoderado/1
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            ApoderadoModel apoderadoQuery = new ApoderadoModel(new Apoderado());
            apoderadoQuery.Apoderado.Rut = id;

            if (apoderadoQuery.Delete())
            {
                ResponseMenssage response = new ResponseMenssage("success", apoderadoQuery.Apoderado);
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