using MediatR;
using SeatInventoryService.Application.Abstractions;
using SeatInventoryService.Domain.Abstractions;
using SeatInventoryService.Domain.Exceptions;

namespace SeatInventoryService.Application.Commands.HoldSeat;

public class HoldSeatCommandHandler : IRequestHandler<HoldSeatCommand>
{
    private readonly ISeatRepository _seatRepository;
    private readonly TimeProvider _timeProvider;
    private readonly IUnitOfWork _unitOfWork;

    public HoldSeatCommandHandler(
        ISeatRepository seatRepository,
        TimeProvider timeProvider,
        IUnitOfWork unitOfWork)
    {
        _seatRepository = seatRepository;
        _timeProvider = timeProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(HoldSeatCommand request, CancellationToken cancellationToken)
    {
        var seat = await _seatRepository.FindByIdAsync(request.SeatId, cancellationToken)
                   ?? throw new SeatNotFoundException(request.SeatId);

        seat.Hold(request.PassengerId, request.HoldDuration, _timeProvider);

        _seatRepository.Save(seat);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}