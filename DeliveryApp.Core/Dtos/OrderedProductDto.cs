﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Core.Dtos
{
    public class OrderedProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual int Quantity { get; set; } = 1;
    }
}
