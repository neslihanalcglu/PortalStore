using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Core.Dtos
{
    public class OrderItemWithNavigationPropertiesDto : OrderItemDto
    {
        public Order Order { get; set; }

        public Sku Sku { get; set; }
    }
}
