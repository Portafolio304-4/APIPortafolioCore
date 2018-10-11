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
    public class TipoPagoController : ControllerBase
    {
        // GET api/tipopago
        [HttpGet]
        public JsonResult Get()
        {
            TipoPagoModel tipoPagoQuery = new TipoPagoModel(new TipoPago());

            ResponseMenssage response = new ResponseMenssage("success", tipoPagoQuery.GetTipos());
            return new JsonResult(response);
        }


        // GET api/tipopago/1
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            TipoPago tipo_pago = new TipoPago
            {
                Id = id
            };
            TipoPagoModel tipoPagoQuery = new TipoPagoModel(tipo_pago);


            if (tipoPagoQuery.ReadById())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoPagoQuery.Tipo_pago);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "tipo_pago no encontrada");
                return new JsonResult(response);
            }
        }

        // POST api/region
        [HttpPost]
        public JsonResult Post([FromBody]TipoPago tipo_pago)
        {
            TipoPagoModel tipoPagoQuery = new TipoPagoModel(tipo_pago);

            if (tipoPagoQuery.Create())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoPagoQuery.Tipo_pago);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al crear region");
                return new JsonResult(response);
            }
        }

        // PUT api/tipopago/1
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]TipoPago tipo_pago)
        {
            TipoPagoModel tipoPagoQuery = new TipoPagoModel(tipo_pago);
            tipoPagoQuery.Tipo_pago.Id = id;

            if (tipoPagoQuery.Update())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoPagoQuery.Tipo_pago);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al modificar tipo_pago");
                return new JsonResult(response);
            }
        }

        // DELETE api/tipopago/1
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            TipoPagoModel tipoPagoQuery = new TipoPagoModel(new TipoPago());
            tipoPagoQuery.Tipo_pago.Id = id;

            if (tipoPagoQuery.Delete())
            {
                ResponseMenssage response = new ResponseMenssage("success", tipoPagoQuery.Tipo_pago);
                return new JsonResult(response);
            }
            else
            {
                ResponseMenssage response = new ResponseMenssage("error", "error al eliminar tipo_pago");
                return new JsonResult(response);
            }
        }

    }
}