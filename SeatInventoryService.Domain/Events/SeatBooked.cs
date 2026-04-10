namespace SeatInventoryService.Domain.Events;

public record SeatBooked(Guid SeatId, Guid FlightId, Guid PassengerId) : DomainEvent;