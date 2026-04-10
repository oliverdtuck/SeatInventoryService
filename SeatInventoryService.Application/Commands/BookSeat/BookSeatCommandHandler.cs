using MediatR;
using SeatInventoryService.Application.Abstractions;
using SeatInventoryService.Domain.Abstractions;
using SeatInventoryService.Domain.Exceptions;

namespace SeatInventoryService.Application.Commands.BookSeat;

public class BookSeatCommandHandler : IRequestHandler<BookSeatCommand>
{
    private readonly ISeatRepository _seatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BookSeatCommandHandler(ISeatRepository seatRepository, IUnitOfWork unitOfWork)
    {
        _seatRepository = seatRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(BookSeatCommand request, CancellationToken cancellationToken)
    {
        var seat = await _seatRepository.FindByIdAsync(request.SeatId, cancellationToken)
                   ?? throw new SeatNotFoundException(request.SeatId);

        seat.Book(request.PassengerId);

        _seatRepository.Save(seat);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}