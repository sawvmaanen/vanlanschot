using Microsoft.AspNetCore.Mvc;
using VanLanschot.ApiService.Models;
using VanLanschot.Core.Ports;

namespace VanLanschot.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController(IStockService stockService) : ControllerBase
    {
        [HttpPost("{stockId}")]
        public async Task<ActionResult> Buy([FromRoute] string stockId, [FromBody] BuyStockRequestModel requestModel, CancellationToken cancellationToken = default)
        {
            var result = await stockService.BuyStock(requestModel.UserId, stockId, requestModel.Amount, cancellationToken);

            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }
            
            return Ok();
        }

        [HttpGet("{stockId}")]
        public async Task<ActionResult<GetStockResponseModel>> Get([FromRoute] string stockId, CancellationToken cancellationToken = default)
        {
            var result = await stockService.GetStockValue(stockId, cancellationToken);
            return Ok(new GetStockResponseModel(100, "USD"));
        }
    }
}
