using FluentValidation;

namespace SeatInventoryService.Application.Commands.HoldSeat;

public class HoldSeatCommandValidator : AbstractValidator<HoldSeatCommand>
{
    public HoldSeatCommandValidator()
    {
        RuleFor(x => x.SeatId).NotEmpty();
        RuleFor(x => x.PassengerId).NotEmpty();
        RuleFor(x => x.HoldDuration).GreaterThan(TimeSpan.Zero);
    }
}