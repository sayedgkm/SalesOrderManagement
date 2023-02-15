using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SalesOrderManagement.Service;

using SalesOrderManagement.Core.Utilities;
using SalesOrderManagement.Core.Enums;
using SalesOrderManagement.Shared;
using AutoMapper;
using System.Collections.Generic;
using SalesOrderManagement.Core.Domain;

namespace SalesOrderManagement.Server.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        private readonly ISalesOrderService _salesOrderService;
        private readonly IMapper _mapper;
        public SalesOrderController(ISalesOrderService salesOrderService, IMapper mapper)
        {
            _salesOrderService = salesOrderService;
            _mapper = mapper; 
        }

        [HttpGet("SalesOrders")]
        public async Task<ActionResult<dynamic>> GetSalesOrder()
        {
            ActionResultDTO<List<SalesOrderDTO>> actionResult = 
                _mapper.Map<ActionResultDTO<List<SalesOrderDTO>>> (await _salesOrderService.GetSalesOrdersAsync());

            if(actionResult.StatusCode == ResponseStatusCodeDTO.UnKnown)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, actionResult);
            }

            return Ok(actionResult);
        }

        [HttpGet("SalesOrder/{salesOrderId}")]
        public async Task<ActionResult<dynamic>> GetSalesOrderDetails(int salesOrderId)
        {
            ActionResultDTO<SalesOrderDTO> actionResult =
                _mapper.Map<ActionResultDTO<SalesOrderDTO>>(await _salesOrderService.GetSalesOrderDetailsAsync(salesOrderId));

            if (actionResult.StatusCode == ResponseStatusCodeDTO.UnKnown)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, actionResult);
            }

            return Ok(actionResult);
        }

        [HttpPost("SalesOrder")]
        public async Task<ActionResult<dynamic>> CreateSalesOrder([FromBody] SalesOrderDTO salesOrder)
        {
            var response = await _salesOrderService.CreateSalesOrderAysnc(_mapper.Map<Order>(salesOrder));
            ActionResultDTO<SalesOrderDTO> actionResult = _mapper.Map<ActionResultDTO<SalesOrderDTO>>(response);
            
            if (actionResult.StatusCode == ResponseStatusCodeDTO.UnKnown)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, actionResult);
            }

            return Ok(actionResult);
        }


        [HttpPut("SalesOrder")]
        public async Task<ActionResult<dynamic>> UpdateSalesOrder([FromBody] SalesOrderDTO salesOrder)
        {
            var response = await _salesOrderService.UpdateSalesOrderAysnc(_mapper.Map<Order>(salesOrder));

            ActionResultDTO<SalesOrderDTO> actionResult = _mapper.Map<ActionResultDTO<SalesOrderDTO>>(response);

            if (actionResult.StatusCode == ResponseStatusCodeDTO.UnKnown)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, actionResult);
            }

            return Ok(actionResult);
        }

        [HttpDelete("SalesOrder/{SalesOrderId}")]
        public async Task<ActionResult<dynamic>> DeleteSalesOrder(int SalesOrderId)
        {
            ActionResultDTO<SalesOrderDTO> actionResult =
                _mapper.Map<ActionResultDTO<SalesOrderDTO>>(await _salesOrderService.DeleteOrderAsync(SalesOrderId));

            if (actionResult.StatusCode == ResponseStatusCodeDTO.UnKnown)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, actionResult);
            }

            return NoContent();
        }

    }
}
