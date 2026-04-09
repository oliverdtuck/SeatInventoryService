using SeatInventoryService.Domain.Events.Base;

namespace SeatInventoryService.Domain.Events;

public record SeatReleased(Guid SeatId, Guid FlightId) : DomainEvent;