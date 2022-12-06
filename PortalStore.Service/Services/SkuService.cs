using PortalStore.Core;
using PortalStore.Core.Repositories;
using PortalStore.Core.Services;
using PortalStore.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Service.Services
{
    public class SkuService : Service<Sku>, ISkuService
    {
        public SkuService(IGenericRepository<Sku> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
