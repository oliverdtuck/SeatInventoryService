using SeatInventoryService.Domain.Enums;

namespace SeatInventoryService.Application.Queries.GetSeatsByFlight;

public record SeatSummary(
    Guid Id,
    int Number,
    CabinClass CabinClass,
    SeatStatus Status,
    DateTime? HoldExpiresAt);