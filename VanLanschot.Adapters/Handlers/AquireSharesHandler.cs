using MediatR;
using VanLanschot.Adapters.Data;
using VanLanschot.Core.Messages;

namespace VanLanschot.Adapters.Handlers;

public class AquireSharesHandler(ISharesRepository sharesRepository) : IRequestHandler<AquireSharesRequest>
{
    public async Task Handle(AquireSharesRequest request, CancellationToken cancellationToken)
    {
        await sharesRepository.AquireShares(request.userId, request.stockId, request.amount);
    }
}
