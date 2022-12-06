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
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<OrderItem>> GetListWithNavigationPropertiesAsync()
        {
            return await _context.OrderItems
                .Include(x => x.Order)
                .Include(y => y.Sku).ToListAsync();
        }

        public async Task<OrderItem> GetWithNavigationPropertieAsync(int id)
        {
            var orderItems = await _context.OrderItems
                .Include(x => x.Order)
                .Include(y => y.Sku).ToListAsync();
            var orderItem = orderItems.Find(x => x.Id == id);
            return orderItem;
        }
    }
}
