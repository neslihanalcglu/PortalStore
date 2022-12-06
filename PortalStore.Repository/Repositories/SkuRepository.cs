using Microsoft.EntityFrameworkCore;
using PortalStore.Core;
using PortalStore.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Repository.Repositories
{
    public class SkuRepository : GenericRepository<Sku>, ISkuRepository
    {
        public SkuRepository(AppDbContext context) : base(context)
        {
        }
    }
}
