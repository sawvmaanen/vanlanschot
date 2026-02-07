namespace VanLanschot.Core.Ports;

public interface IPortfolioService
{
    Task<decimal> GetSharesAmount(string userId, string stockId, CancellationToken cancellationToken);
    Task AquireShares(string userId, string stockId, decimal amount, CancellationToken cancellationToken);
}