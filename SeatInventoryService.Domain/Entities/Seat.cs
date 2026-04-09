using SeatInventoryService.Domain.Enums;
using SeatInventoryService.Domain.Events;

namespace SeatInventoryService.Domain.Entities;

public class Seat : Entity
{
    public Guid Id { get; private set; }
    public Guid FlightId { get; private set; }
    public int Number { get; private set; }
    public CabinClass CabinClass { get; private set; }
    public SeatStatus Status { get; private set; }
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

    public void Hold(Guid passengerId, DateTime expiresAt)
    {
        if (Status != SeatStatus.Available)
        {
            throw new InvalidOperationException("Seat is not available.");
        }

        Status = SeatStatus.Held;
        
        RaiseDomainEvent(new SeatHeld(Id, FlightId, passengerId, expiresAt));
    }

    public void Book(Guid passengerId)
    {
        if (Status != SeatStatus.Held)
        {
            throw new InvalidOperationException("Seat must be held before booking.");
        }

        Status = SeatStatus.Booked;
        
        RaiseDomainEvent(new SeatBooked(Id, FlightId, passengerId));
    }

    public void Release()
    {
        if (Status == SeatStatus.Booked)
        {
            throw new InvalidOperationException("Cannot release a booked seat.");
        }

        Status = SeatStatus.Available;
        
        RaiseDomainEvent(new SeatReleased(Id, FlightId));
    }

    public void MarkUnavailable()
    {
        if (Status == SeatStatus.Booked)
        {
            throw new InvalidOperationException("Cannot mark a booked seat as unavailable.");
        }

        Status = SeatStatus.Unavailable;
        
        RaiseDomainEvent(new SeatMarkedUnavailable(Id, FlightId));
    }
}