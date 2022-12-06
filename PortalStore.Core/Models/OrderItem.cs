using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Core
{
    public class OrderItem: BaseEntity
    {
        public int SkuId { get; set; }
        public int OrderId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Sku Sku { get; set; }
        public Order Order { get; set; }
    }
}
