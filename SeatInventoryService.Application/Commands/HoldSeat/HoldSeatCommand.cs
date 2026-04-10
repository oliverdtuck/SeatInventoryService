using MediatR;

namespace SeatInventoryService.Application.Commands.HoldSeat;

public record HoldSeatCommand(Guid SeatId, Guid PassengerId, TimeSpan HoldDuration) : IRequest;