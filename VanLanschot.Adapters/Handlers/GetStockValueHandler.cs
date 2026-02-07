using MediatR;
using VanLanschot.Adapters.Data;
using VanLanschot.Core.Messages;

namespace VanLanschot.Adapters.Handlers;

public class GetStockValueHandler(IStockValuesRepository stockValuesRepository) : IRequestHandler<GetStockValueRequest, decimal>
{
    public async Task<decimal> Handle(GetStockValueRequest request, CancellationToken cancellationToken)
    {
        return await stockValuesRepository.GetByStockId(request.stockId);
    }
}
