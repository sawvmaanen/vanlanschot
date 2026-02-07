using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanLanschot.Core.Ports;

namespace VanLanschot.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfoliosController(IPortfolioService portfolioService) : ControllerBase
    {
        [HttpGet("{userId}/{stockId}")]
        public async Task<ActionResult<decimal>> Get([FromRoute] string userId, string stockId, CancellationToken cancellationToken = default)
        {
            var result = await portfolioService.GetSharesAmount(userId, stockId, cancellationToken);
            return Ok(result);
        }
    }
}
