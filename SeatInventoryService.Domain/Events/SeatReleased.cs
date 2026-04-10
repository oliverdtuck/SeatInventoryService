namespace SeatInventoryService.Domain.Events;

public record SeatReleased(Guid SeatId, Guid FlightId, Guid PassengerId) : DomainEvent;