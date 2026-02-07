using ErrorOr;

namespace VanLanschot.Core.Ports;

public interface IFundsService
{
    Task<decimal> GetFunds(string userId, CancellationToken cancellationToken = default);
    Task SpendFunds(string userId, decimal amount, CancellationToken cancellationToken = default);
}