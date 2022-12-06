using PortalStore.Core.Models;
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
    public class AddressService : Service<Address>, IAddressService
    {
        public AddressService(IGenericRepository<Address> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
