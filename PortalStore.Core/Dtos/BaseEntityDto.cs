using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Core.Dtos
{
    public abstract class BaseEntityDto
    {
        public bool Status { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
