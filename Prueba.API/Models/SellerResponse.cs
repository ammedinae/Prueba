using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.API.Models
{
    public class SellerResponse
    {
        public long Code { get; set; }
        public string Names { get; set; }
        public string Last_Name { get; set; }
        public long Document { get; set; }
        public long City_Id { get; set; }
        public string City_Description { get; set; }
    }
}