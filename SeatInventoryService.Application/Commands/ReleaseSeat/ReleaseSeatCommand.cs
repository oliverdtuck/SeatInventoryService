using MediatR;

namespace SeatInventoryService.Application.Commands.ReleaseSeat;

public record ReleaseSeatCommand(Guid SeatId) : IRequest;