﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
   public class PartInputDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int SupplierId { get; set; }
    }
}
