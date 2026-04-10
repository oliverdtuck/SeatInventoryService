using MediatR;
using SeatInventoryService.Domain.Abstractions;

namespace SeatInventoryService.Application.Queries.GetSeatsByFlight;

public class GetSeatsByFlightQueryHandler : IRequestHandler<GetSeatsByFlightQuery, IReadOnlyList<SeatSummary>>
{
    private readonly ISeatRepository _seatRepository;

    public GetSeatsByFlightQueryHandler(ISeatRepository seatRepository)
    {
        _seatRepository = seatRepository;
    }

    public async Task<IReadOnlyList<SeatSummary>> Handle(GetSeatsByFlightQuery request,
        CancellationToken cancellationToken)
    {
        var seats = await _seatRepository.ListByFlightIdAsync(request.FlightId, cancellationToken);

        return seats
            .Select(s => new SeatSummary(s.Id, s.Number, s.CabinClass, s.Status, s.ActiveHold?.ExpiresAt))
            .ToList();
    }
}