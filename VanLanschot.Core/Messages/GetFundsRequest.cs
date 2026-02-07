using MediatR;

namespace VanLanschot.Core.Messages;

public record GetFundsRequest(string userId) : IRequest<decimal>;

