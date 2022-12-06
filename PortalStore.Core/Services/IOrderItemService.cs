using PortalStore.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Core.Services
{
    public interface IOrderItemService : IService<OrderItem>
    {
        Task<CustomResponseDto<List<OrderItemWithNavigationPropertiesDto>>> GetListWithNavigationPropertiesAsync();
        Task<CustomResponseDto<OrderItemWithNavigationPropertiesDto>> GetWithNavigationPropertieAsync(int id);
    }
}
