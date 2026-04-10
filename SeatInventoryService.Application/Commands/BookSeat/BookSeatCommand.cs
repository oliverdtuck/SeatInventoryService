using MediatR;

namespace SeatInventoryService.Application.Commands.BookSeat;

public record BookSeatCommand(Guid SeatId, Guid PassengerId) : IRequest;