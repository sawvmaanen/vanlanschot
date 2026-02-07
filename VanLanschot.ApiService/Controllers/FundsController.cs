using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanLanschot.ApiService.Models;
using VanLanschot.Core.Ports;

namespace VanLanschot.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundsController(IFundsService fundsService) : ControllerBase
    {
        [HttpGet("{userId}")]
        public async Task<ActionResult<decimal>> Get([FromRoute] string userId, CancellationToken cancellationToken = default)
        {
            var result = await fundsService.GetFunds(userId, cancellationToken);
            return result;
        }
    }
}
