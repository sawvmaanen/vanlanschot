using MediatR;
using VanLanschot.Core.Messages;
using VanLanschot.Core.Ports;

namespace VanLanschot.Core;

public class PortfolioService(IMediator mediator) : IPortfolioService
{
    public async Task<decimal> GetSharesAmount(string userId, string stockId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new GetSharesAmountRequest(userId, stockId), cancellationToken);
        return result;
    }

    public async Task AquireShares(string userId, string stockId, decimal amount, CancellationToken cancellationToken = default)
    {
        await mediator.Send(new AquireSharesRequest(userId, stockId, amount), cancellationToken);
    }
}
