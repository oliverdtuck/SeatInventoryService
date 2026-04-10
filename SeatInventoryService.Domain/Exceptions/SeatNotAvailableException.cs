namespace SeatInventoryService.Domain.Exceptions;

public class SeatNotAvailableException : DomainException
{
    public SeatNotAvailableException(Guid seatId)
        : base($"Seat '{seatId}' is not available.")
    {
    }
}