﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MokinVarausApp.Models
{
    public class Cottage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AreaId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
