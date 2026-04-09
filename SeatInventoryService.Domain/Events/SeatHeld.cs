using SeatInventoryService.Domain.Events.Base;

namespace SeatInventoryService.Domain.Events;

public record SeatHeld(Guid SeatId, Guid FlightId, Guid PassengerId, DateTime ExpiresAt) : DomainEvent;