namespace SeatInventoryService.Domain.Events;

public record SeatMarkedUnavailable(Guid SeatId, Guid FlightId) : DomainEvent;