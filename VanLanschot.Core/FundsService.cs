using ErrorOr;
using MediatR;
using VanLanschot.Core.Messages;
using VanLanschot.Core.Ports;

namespace VanLanschot.Core;

public class FundsService(IMediator mediator) : IFundsService
{
    public async Task<decimal> GetFunds(string userId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new GetFundsRequest(userId), cancellationToken);

        return result;
    }

    public async Task SpendFunds(string userId, decimal amount, CancellationToken cancellationToken = default)
    {
        await mediator.Send(new SpendFundsRequest(userId, amount), cancellationToken);
    }
}
