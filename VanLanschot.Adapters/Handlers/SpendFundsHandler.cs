using MediatR;
using VanLanschot.Adapters.Data;
using VanLanschot.Core.Messages;

namespace VanLanschot.Adapters.Handlers;

public class SpendFundsHandler(IFundsRepository fundsRepository) : IRequestHandler<SpendFundsRequest>
{
    public async Task Handle(SpendFundsRequest request, CancellationToken cancellationToken)
    {
        await fundsRepository.SpendByUserId(request.userId, request.amount);
    }
}
