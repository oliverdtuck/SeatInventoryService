using MediatR;
using SeatInventoryService.Application.Abstractions;
using SeatInventoryService.Domain.Abstractions;
using SeatInventoryService.Domain.Exceptions;

namespace SeatInventoryService.Application.Commands.ReleaseSeat;

public class ReleaseSeatCommandHandler : IRequestHandler<ReleaseSeatCommand>
{
    private readonly ISeatRepository _seatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReleaseSeatCommandHandler(ISeatRepository seatRepository, IUnitOfWork unitOfWork)
    {
        _seatRepository = seatRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(ReleaseSeatCommand request, CancellationToken cancellationToken)
    {
        var seat = await _seatRepository.FindByIdAsync(request.SeatId, cancellationToken)
                   ?? throw new SeatNotFoundException(request.SeatId);

        seat.Release();

        _seatRepository.Save(seat);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}