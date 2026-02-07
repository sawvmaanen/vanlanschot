using MediatR;

namespace VanLanschot.Core.Messages;

public record AquireSharesRequest(string userId, string stockId, decimal amount) : IRequest;

