namespace VanLanschot.Adapters.Data;

public interface ISharesRepository
{
    Task AquireShares(string userId, string stockId, decimal amount);
    Task<decimal> GetAmount(string userId, string stockId);
}

public class SharesRepository : ISharesRepository
{
    private decimal _amountOfShares = 0;

    public async Task<decimal> GetAmount(string userId, string stockId)
    {
        return _amountOfShares;
    }

    public async Task AquireShares(string userId, string stockId, decimal amount)
    {
        _amountOfShares += amount;
    }
}
