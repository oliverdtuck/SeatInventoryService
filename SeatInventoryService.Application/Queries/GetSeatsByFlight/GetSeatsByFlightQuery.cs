using MediatR;

namespace SeatInventoryService.Application.Queries.GetSeatsByFlight;

public record GetSeatsByFlightQuery(Guid FlightId) : IRequest<IReadOnlyList<SeatSummary>>;