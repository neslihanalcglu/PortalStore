using PortalStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Core
{
    public class Customer: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long TCID { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gsm { get; set; }
        public ICollection<Address>? Addresses { get; set; } // navigation property
        public ICollection<Order>? Orders { get; set; }
    }
}
