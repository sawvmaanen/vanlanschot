using MediatR;
using VanLanschot.Adapters.Data;
using VanLanschot.Core.Messages;

namespace VanLanschot.Adapters.Handlers;

public class GetFundsHandler(IFundsRepository fundsRepository) : IRequestHandler<GetFundsRequest, decimal>
{
    public async Task<decimal> Handle(GetFundsRequest request, CancellationToken cancellationToken)
    {
        return await fundsRepository.GetByUserId(request.userId);
    }
}
