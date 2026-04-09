using SeatInventoryService.Domain.Entities;

namespace SeatInventoryService.Domain.Repositories;

public interface ISeatRepository
{
    Task<Seat?> GetByIdAsync(Guid seatId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Seat>> GetByFlightIdAsync(Guid flightId, CancellationToken cancellationToken = default);
    Task AddAsync(Seat seat, CancellationToken cancellationToken = default);
    Task UpdateAsync(Seat seat, CancellationToken cancellationToken = default);
}