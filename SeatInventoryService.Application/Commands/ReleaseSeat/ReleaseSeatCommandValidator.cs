using FluentValidation;

namespace SeatInventoryService.Application.Commands.ReleaseSeat;

public class ReleaseSeatCommandValidator : AbstractValidator<ReleaseSeatCommand>
{
    public ReleaseSeatCommandValidator()
    {
        RuleFor(x => x.SeatId).NotEmpty();
    }
}