using SalesOrderManagement.Core.Domain;
using SalesOrderManagement.Core.Enums;
using SalesOrderManagement.Core.Utilities;
using SalesOrderManagement.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManagement.Service
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly ISalesOrderRepository _salesOrderRepository;

        public SalesOrderService(ISalesOrderRepository salesOrderRepository)
        {
            _salesOrderRepository = salesOrderRepository;
        }

        public async Task<FunctionResult<List<Order>>> GetSalesOrdersAsync()
        {
            FunctionResult<List<Order>> functionResult = FunctionResult<List<Order>>.Default;
            try
            {
                var salesOrders = await _salesOrderRepository.GetSalesOrdersAsync();
                functionResult.Response = salesOrders;

            } catch (Exception ex)
            {
                functionResult.StatusCode = ResponseStatusCode.UnKnown;
                functionResult.Message = "Internal Server Error occurred.";
            }

            return functionResult;
        }

        public async Task<FunctionResult<Order>> GetSalesOrderDetailsAsync(int id)
        {
            FunctionResult<Order> functionResult = FunctionResult<Order>.Default;
            try
            {
                var salesOrders = await _salesOrderRepository.GetSalesOrderDetailsAsync(id);
                
                functionResult.Response = salesOrders;

            } catch (Exception ex)
            {
                functionResult.StatusCode = ResponseStatusCode.UnKnown;
                functionResult.Message = "Internal Server Error occurred.";
            }

            return functionResult;
        }

        public async Task<FunctionResult<Order>> CreateSalesOrderAysnc(Order order)
        {
            FunctionResult<Order> functionResult = FunctionResult<Order>.Default;
            try
            {
                order.CreatedOn = DateTime.Now;
                var response = await _salesOrderRepository.CreateSalesOrderAysnc(order);
                functionResult.Response = response;

            } catch (Exception ex)
            {
                functionResult.StatusCode = ResponseStatusCode.UnKnown;
                functionResult.Message = "Internal Server Error occurred.";
            }

            return functionResult;
        }


        public async Task<FunctionResult<Order>> UpdateSalesOrderAysnc(Order orderToModify)
        {
            FunctionResult<Order> functionResult = FunctionResult<Order>.Default;
            try
            {
                var order = await _salesOrderRepository.GetSalesOrderDetailsAsync(orderToModify.Id);
                orderToModify.CreatedOn = order.CreatedOn;
                var response = await _salesOrderRepository.UpdateSalesOrderAysnc(order, orderToModify);
                functionResult.Response = response;

            } catch (Exception ex)
            {
                functionResult.StatusCode = ResponseStatusCode.UnKnown;
                functionResult.Message = "Internal Server Error occurred.";
            }

            return functionResult;
        }

        public async Task<FunctionResult<Order>> DeleteOrderAsync(int id)
        {
            FunctionResult<Order> functionResult = FunctionResult<Order>.Default;

            try
            {
                Order order = await _salesOrderRepository.GetSalesOrderDetailsAsync(id);
                var response = await _salesOrderRepository.DeleteOrderAsync(order);
                functionResult.Response = response;

            } catch (Exception ex)
            {
                functionResult.StatusCode = ResponseStatusCode.UnKnown;
                functionResult.Message = "Internal Server Error occurred.";
            }

            return functionResult;

        }

    }
}
