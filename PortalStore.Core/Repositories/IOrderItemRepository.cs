using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Core.Repositories
{
    public interface IOrderItemRepository : IGenericRepository<OrderItem>
    {
        Task<List<OrderItem>> GetListWithNavigationPropertiesAsync();
        Task<OrderItem> GetWithNavigationPropertieAsync(int id);
    }
}
