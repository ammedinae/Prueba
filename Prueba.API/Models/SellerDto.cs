﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.API.Models
{
    public class SellerDto
    {
        public long Code { get; set; }
        public string Names { get; set; }
        public string Last_Name { get; set; }
        public long Document { get; set; }
        public long City_Id { get; set; }
    }
}