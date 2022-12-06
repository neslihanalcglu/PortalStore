﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Core.Dtos
{
    public class SkuDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
