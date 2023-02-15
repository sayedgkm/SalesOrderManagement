using SalesOrderManagement.Core.Domain;
using SalesOrderManagement.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManagement.Service
{
    public interface ISalesOrderService
    {
        Task<FunctionResult<List<Order>>> GetSalesOrdersAsync();
        Task<FunctionResult<Order>> GetSalesOrderDetailsAsync(int id);
        Task<FunctionResult<Order>> CreateSalesOrderAysnc(Order order);
        Task<FunctionResult<Order>> UpdateSalesOrderAysnc(Order orderToModify);
        Task<FunctionResult<Order>> DeleteOrderAsync(int id);
    }
}
