using Prueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.API.Models
{
    public class City
    {
        public static List<CityResponse> ConsutarCity()
        {
            try
            {
                List<CityResponse> lstCity = new List<CityResponse>();

                using (dboPruebaEntities db = new dboPruebaEntities())
                {
                    lstCity = (from c in db.City
                               select new CityResponse
                               {
                                   Code = c.Code,
                                   Description = c.Description
                               }).ToList();
                }

                return lstCity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}