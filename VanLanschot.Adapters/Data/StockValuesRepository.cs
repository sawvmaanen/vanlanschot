namespace VanLanschot.Adapters.Data;

public interface IStockValuesRepository
{
    Task<decimal> GetByStockId(string stockId);
}

public class StockValuesRepository : IStockValuesRepository
{
    public async Task<decimal> GetByStockId(string stockId)
    {
        return 100;
    }
}
