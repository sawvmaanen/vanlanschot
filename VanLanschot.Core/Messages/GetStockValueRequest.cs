using MediatR;

namespace VanLanschot.Core.Messages;

public record GetStockValueRequest(string stockId) : IRequest<decimal>;

