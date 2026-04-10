namespace SeatInventoryService.Domain.Exceptions;

public class SeatNotHeldException : DomainException
{
    public SeatNotHeldException(Guid seatId)
        : base($"Seat '{seatId}' is not currently held.")
    {
    }
}