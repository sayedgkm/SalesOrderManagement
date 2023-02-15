using SalesOrderManagement.Core.Domain;
using SalesOrderManagement.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManagement.Data.Repositories
{
    public interface ISalesOrderRepository
    {
        Task<List<Order>> GetSalesOrdersAsync();
        Task<Order> GetSalesOrderDetailsAsync(int id);
        Task<Order> CreateSalesOrderAysnc(Order order);
        Task<Order> UpdateSalesOrderAysnc(Order order, Order orderToModify);
        Task<Order> DeleteOrderAsync(Order order);
    }
}
