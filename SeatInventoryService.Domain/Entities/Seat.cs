using SeatInventoryService.Domain.Enums;
using SeatInventoryService.Domain.Events;
using SeatInventoryService.Domain.ValueObjects;

namespace SeatInventoryService.Domain.Entities;

public class Seat : Entity
{
    public Guid Id { get; private set; }
    public Guid FlightId { get; private set; }
    public int Number { get; private set; }
    public CabinClass CabinClass { get; private set; }
    public SeatStatus Status { get; private set; }
    public SeatHold? ActiveHold { get; private set; }
    public uint Version { get; private set; }

    public static Seat Create(Guid flightId, int number, CabinClass cabinClass)
    {
        return new Seat
        {
            Id = Guid.NewGuid(),
            FlightId = flightId,
            Number = number,
            CabinClass = cabinClass,
            Status = SeatStatus.Available,
            Version = 0
        };
    }

    public void Hold(Guid passengerId, TimeSpan holdDuration, TimeProvider timeProvider)
    {
        if (Status != SeatStatus.Available) throw new InvalidOperationException("Seat is not available.");

        ActiveHold = SeatHold.Create(passengerId, holdDuration, timeProvider);
        Status = SeatStatus.Held;

        RaiseDomainEvent(new SeatHeld(Id, FlightId, passengerId, ActiveHold.ExpiresAt));
    }

    public void Book(Guid passengerId)
    {
        if (Status != SeatStatus.Held) throw new InvalidOperationException("Seat must be held before booking.");

        ActiveHold = null;
        Status = SeatStatus.Booked;

        RaiseDomainEvent(new SeatBooked(Id, FlightId, passengerId));
    }

    public void Release()
    {
        RaiseDomainEvent(new SeatReleased(Id, FlightId, ClearHold()));
    }

    public void ExpireHold()
    {
        RaiseDomainEvent(new SeatHoldExpired(Id, FlightId, ClearHold()));
    }

    public void MarkUnavailable()
    {
        if (Status != SeatStatus.Available)
            throw new InvalidOperationException("Only an available seat can be marked unavailable.");

        Status = SeatStatus.Unavailable;

        RaiseDomainEvent(new SeatMarkedUnavailable(Id, FlightId));
    }

    private Guid ClearHold()
    {
        if (ActiveHold is null) throw new InvalidOperationException("Seat has no active hold.");

        var passengerId = ActiveHold.PassengerId;

        ActiveHold = null;
        Status = SeatStatus.Available;

        return passengerId;
    }
}