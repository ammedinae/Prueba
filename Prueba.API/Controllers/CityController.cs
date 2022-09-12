using Prueba.API.Models;
using Prueba.Models;
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
    [RoutePrefix("api/City")]
    public class CityController : ApiController
    {
        [HttpGet]
        [Route("City")]
        [ResponseType(typeof(IEnumerable<CityResponse>))]
        public IHttpActionResult CityConsultar()
        {
            try
            {
                var lstCity = Models.City.ConsutarCity();

                if (lstCity.Count > 0)
                {
                    return Ok(lstCity);
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