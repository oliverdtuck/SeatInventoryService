using SeatInventoryService.Domain.Entities;

namespace SeatInventoryService.Domain.Abstractions;

public interface ISeatRepository : IRepository<Seat>
{
    Task<IReadOnlyList<Seat>> ListByFlightIdAsync(Guid flightId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Seat>> ListWithExpiredHoldsAsync(CancellationToken cancellationToken = default);
}