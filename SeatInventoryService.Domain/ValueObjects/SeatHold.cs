namespace SeatInventoryService.Domain.ValueObjects;

public record SeatHold
{
    public Guid PassengerId { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime ExpiresAt { get; init; }

    public bool IsExpired(TimeProvider timeProvider)
    {
        return timeProvider.GetUtcNow().UtcDateTime > ExpiresAt;
    }

    public static SeatHold Create(Guid passengerId, TimeSpan holdDuration, TimeProvider timeProvider)
    {
        var now = timeProvider.GetUtcNow().UtcDateTime;

        return new SeatHold
        {
            PassengerId = passengerId,
            CreatedAt = now,
            ExpiresAt = now.Add(holdDuration)
        };
    }
}