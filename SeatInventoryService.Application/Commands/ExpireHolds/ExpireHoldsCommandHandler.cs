using MediatR;
using SeatInventoryService.Application.Abstractions;
using SeatInventoryService.Domain.Abstractions;

namespace SeatInventoryService.Application.Commands.ExpireHolds;

public class ExpireHoldsCommandHandler : IRequestHandler<ExpireHoldsCommand, int>
{
    private readonly ISeatRepository _seatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ExpireHoldsCommandHandler(ISeatRepository seatRepository, IUnitOfWork unitOfWork)
    {
        _seatRepository = seatRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(ExpireHoldsCommand request, CancellationToken cancellationToken)
    {
        var seats = await _seatRepository.ListWithExpiredHoldsAsync(cancellationToken);

        foreach (var seat in seats)
        {
            seat.ExpireHold();
            _seatRepository.Save(seat);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return seats.Count;
    }
}