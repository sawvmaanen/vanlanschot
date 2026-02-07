using MediatR;

namespace VanLanschot.Core.Messages;

public record SpendFundsRequest(string userId, decimal amount) : IRequest;

