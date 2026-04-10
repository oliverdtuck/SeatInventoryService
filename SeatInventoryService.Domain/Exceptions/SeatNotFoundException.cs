namespace SeatInventoryService.Domain.Exceptions;

public class SeatNotFoundException : DomainException
{
    public SeatNotFoundException(Guid seatId)
        : base($"Seat '{seatId}' was not found.")
    {
    }
}