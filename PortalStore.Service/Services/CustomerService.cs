using PortalStore.Core;
using PortalStore.Core.Dtos;
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
    public class CustomerService : Service<Customer>, ICustomerService

    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork, ICustomerRepository customerRepository) : base(repository, unitOfWork)
        {
            _customerRepository = customerRepository;
        }

    }
}
