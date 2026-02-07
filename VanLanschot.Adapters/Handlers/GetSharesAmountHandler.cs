using MediatR;
using VanLanschot.Adapters.Data;
using VanLanschot.Core.Messages;

namespace VanLanschot.Adapters.Handlers;

public class GetSharesAmountHandler(ISharesRepository sharesRepository) : IRequestHandler<GetSharesAmountRequest, decimal>
{
    public async Task<decimal> Handle(GetSharesAmountRequest request, CancellationToken cancellationToken)
    {
        return await sharesRepository.GetAmount(request.userId, request.stockId);
    }
}
