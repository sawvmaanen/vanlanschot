using ErrorOr;

namespace VanLanschot.Core.Ports;

public interface IStockService
{
    Task<decimal> GetStockValue(string stockId, CancellationToken cancellationToken);
    Task<ErrorOr<Success>> BuyStock(string userId, string stockId, decimal amount, CancellationToken cancellationToken);
}