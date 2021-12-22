using System;
using System.Linq;
using System.Threading.Tasks;
using Acrelec.SCO.Core.Interfaces;
using Acrelec.SCO.Core.Model.RestExchangedMessages;
using Microsoft.AspNetCore.Mvc;

namespace Acrelec.SCO.Server.Controllers
{
    [ApiController]
    [Route("/api-sco/v1")]
    [Produces("application/json")]
    public class CoreController : ControllerBase
    {

        private readonly IOrderManager _orderManager;
        private readonly IItemsProvider _itemsProvider;

        public CoreController(IOrderManager orderManager, IItemsProvider itemsProvider)
        {
            _orderManager = orderManager;
            _itemsProvider = itemsProvider;
        }

        [HttpGet("availability")]
        [ProducesDefaultResponseType(typeof(CheckAvailabilityResponse))]
        public IActionResult GetAvailability()
        {
            var result = new CheckAvailabilityResponse
            {
                CanInjectOrders = _itemsProvider.AvailablePOSItems.Any()
            };

            return Ok(result);
        }

        [HttpPost("injectorder")]
        [ProducesDefaultResponseType(typeof(InjectOrderResponse))]
        public async Task<IActionResult> PostInjectOrder([FromBody] InjectOrderRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Customer details are missing");
            } 

            try
            {
                var result = new InjectOrderResponse
                {
                    OrderNumber = await _orderManager.InjectOrderAsync(model.Order)
                };

                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

    }
}
