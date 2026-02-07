using MediatR;

namespace VanLanschot.Core.Messages;

public record GetSharesAmountRequest(string userId, string stockId) : IRequest<decimal>;

