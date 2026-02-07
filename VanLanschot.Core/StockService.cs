using ErrorOr;
using MediatR;
using VanLanschot.Core.Messages;
using VanLanschot.Core.Ports;

namespace VanLanschot.Core;

public class StockService(IMediator mediator, IFundsService fundsService, IPortfolioService portfolioService) : IStockService
{
    public async Task<decimal> GetStockValue(string stockId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new GetStockValueRequest(stockId), cancellationToken);

        return result;
    }

    public async Task<ErrorOr<Success>> BuyStock(string userId, string stockId, decimal stockAmount, CancellationToken cancellationToken = default)
    {
        var stockValue = await GetStockValue(stockId, cancellationToken);
        var funds = await fundsService.GetFunds(userId, cancellationToken);

        if (stockAmount < 1)
        {
            return Error.Failure(description: "Must buy at least 1.");
        }

        if (funds < stockAmount * stockValue)
        {
            return Error.Failure(description: "Not enough funds.");
        }

        await fundsService.SpendFunds(userId, stockAmount * stockValue, cancellationToken);
        await portfolioService.AquireShares(userId, stockId, stockAmount, cancellationToken);

        return Result.Success;
    }
}
