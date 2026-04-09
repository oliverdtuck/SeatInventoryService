using SeatInventoryService.Domain.Entities;

namespace SeatInventoryService.Domain.Repositories;

public interface ISeatHoldRepository
{
    Task<SeatHold?> GetByIdAsync(Guid holdId, CancellationToken cancellationToken = default);
    Task<SeatHold?> GetActiveBySeatIdAsync(Guid seatId, CancellationToken cancellationToken = default);
    Task AddAsync(SeatHold hold, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid holdId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<SeatHold>> GetExpiredHoldsAsync(CancellationToken cancellationToken = default);
}