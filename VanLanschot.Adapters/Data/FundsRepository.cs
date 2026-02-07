namespace VanLanschot.Adapters.Data;

public interface IFundsRepository
{
    Task<decimal> GetByUserId(string userId);
    Task SpendByUserId(string userId, decimal amount);
}

public class FundsRepository : IFundsRepository
{
    private decimal _balance = 250;

    public async Task<decimal> GetByUserId(string userId)
    {
        return _balance;
    }

    public async Task SpendByUserId(string userId, decimal amount)
    {
        _balance -= amount;
    }
}
