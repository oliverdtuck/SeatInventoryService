namespace SeatInventoryService.Domain.Events;

public record SeatHoldExpired(Guid SeatId, Guid FlightId, Guid PassengerId) : DomainEvent;