using Prueba.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Prueba.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Seller")]
    public class SellerController : ApiController
    {
        [HttpGet]
        [Route("SellerConsulta")]
        [ResponseType(typeof(IEnumerable<SellerController>))]
        public IHttpActionResult SellerConsultar()
        {
            try
            {
                var lstSeller = Models.Seller.SellerConsulta();

                if (lstSeller.Count > 0)
                {
                    return Ok(lstSeller);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("SellerConsulaId")]
        [ResponseType(typeof(IEnumerable<SellerController>))]
        public IHttpActionResult SellerConsulaId(long id)
        {
            try
            {
                var lstSeller = Models.Seller.SellerConsultaId(id);

                if (lstSeller.Code > 0)
                {
                    return Ok(lstSeller);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("SellerCrear")]
        public IHttpActionResult SellerCrear([FromBody] SellerDto sellerDto)
        {
            try
            {
                bool valida = Models.Seller.SellerCrear(sellerDto);

                if (valida)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("SellerEliminar")]
        public IHttpActionResult SellerEliminar(long id)
        {
            try
            {
                bool valida = Models.Seller.SellerEliminar(id);

                if (valida)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}