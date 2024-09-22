using AwesomeShop.Services.Orders.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Core.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByAsync(Guid id);

        Task AddAsync(Order order);

        Task UpdateAsync(Order order);
    }
}
