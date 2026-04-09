namespace SeatInventoryService.Domain.Entities;

public class SeatHold : Entity
{
    public Guid Id { get; private set; }
    public Guid SeatId { get; private set; }
    public Guid PassengerId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime ExpiresAt { get; private set; }

    public bool IsExpired => DateTime.UtcNow > ExpiresAt;

    public static SeatHold Create(Guid seatId, Guid passengerId, TimeSpan holdDuration)
    {
        var now = DateTime.UtcNow;
        
        return new SeatHold
        {
            Id = Guid.NewGuid(),
            SeatId = seatId,
            PassengerId = passengerId,
            CreatedAt = now,
            ExpiresAt = now.Add(holdDuration)
        };
    }
}