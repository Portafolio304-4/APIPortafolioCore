using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace ApiPortafolioCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {   
        // GET api/region
        [HttpGet]
        public JsonResult Get()
        {
            RegionModel regionQuery = new RegionModel(new Region());

            ResponseMenssage response = new ResponseMenssage("success", regionQuery.GetRegions());
            return new JsonResult(response);
        }
       
        // POST api/region
        [HttpPost]
        public JsonResult Post([FromBody]Region region)
        {
            RegionModel regionQuery = new RegionModel(region);

            if (regionQuery.Create())
            {
                ResponseMenssage response = new ResponseMenssage("success", regionQuery.Region);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al crear region");
                return new JsonResult(response);
            }
        }

        // GET api/region/1
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Region region = new Region
            {
                Id = id
            };
            RegionModel regionQuery = new RegionModel(region);


            if (regionQuery.ReadById())
            {
                ResponseMenssage response = new ResponseMenssage("success", regionQuery.Region);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "region no encontrada");
                return new JsonResult(response);
            }
        }

        // PUT api/region/1
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]Region region)
        {
            RegionModel regionQuery = new RegionModel(region);
            regionQuery.Region.Id = id;

            if (regionQuery.Update())
            {
                ResponseMenssage response = new ResponseMenssage("success", regionQuery.Region);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al modificar");
                return new JsonResult(response);
            }
        }

        // DELETE api/region/1
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            RegionModel regionQuery = new RegionModel(new Region());
            regionQuery.Region.Id = id;

            if (regionQuery.Delete())
            {
                ResponseMenssage response = new ResponseMenssage("success", regionQuery.Region);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al eliminar");
                return new JsonResult(response);
            }
        }

        // GET api/region/1/provincia
        [HttpGet("{id_region}/provincia")]
        public JsonResult GetProvincias(int id_region)
        {
            Provincia provincia = new Provincia();
            provincia.Id_region = id_region;
            ProvinciaModel provinciaQuery = new ProvinciaModel(provincia);

            ResponseMenssage response = new ResponseMenssage("success", provinciaQuery.GetProvinciasByRegion());
            return new JsonResult(response);

        }

        // POST api/region/1/provincia
        [HttpPost("{id}/provincia")]
        public JsonResult PostProvincia(int id, [FromBody]Provincia provincia)
        {
            provincia.Id_region = id;

            ProvinciaModel provinciaQuery = new ProvinciaModel(provincia);


            if (provinciaQuery.Create())
            {
                ResponseMenssage response = new ResponseMenssage("success", provinciaQuery.Provincia);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al crear provincia");
                return new JsonResult(response);
            }

        }
    }
}