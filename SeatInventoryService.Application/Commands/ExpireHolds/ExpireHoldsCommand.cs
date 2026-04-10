using MediatR;

namespace SeatInventoryService.Application.Commands.ExpireHolds;

public record ExpireHoldsCommand : IRequest<int>;