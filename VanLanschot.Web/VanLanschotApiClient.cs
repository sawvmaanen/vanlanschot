using VanLanschot.Web.Models;

namespace VanLanschot.Web;

public class VanLanschotApiClient(HttpClient httpClient)
{
    public async Task<GetStockViewModel?> GetStockValueAsync(string stockId, CancellationToken cancellationToken = default)
    {
        var stock = await httpClient.GetFromJsonAsync<GetStockResponseModel>($"/api/stock/{stockId}", cancellationToken);

        if (stock is null)
        {
            return null;
        }

        return new GetStockViewModel(stockId, stock.Price, stock.Currency);
    }

    public async Task<decimal> GetFundsAsync(string userId, CancellationToken cancellationToken = default)
    {
        var funds = await httpClient.GetFromJsonAsync<decimal>($"/api/funds/{userId}", cancellationToken);

        return funds;
    }

    public async Task<decimal> GetSharesAsync(string userId, string stockId, CancellationToken cancellationToken = default)
    {
        var shares = await httpClient.GetFromJsonAsync<decimal>($"/api/portfolios/{userId}/{stockId}", cancellationToken);

        return shares;
    }

    public async Task BuyShares(string userId, string stockId, decimal amount, CancellationToken cancellationToken = default)
    {
        var result = await httpClient.PostAsJsonAsync($"/api/stock/{stockId}", new BuyStockRequestModel(userId, amount), cancellationToken);
    }
}
