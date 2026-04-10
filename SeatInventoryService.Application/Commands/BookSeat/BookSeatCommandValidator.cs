using FluentValidation;

namespace SeatInventoryService.Application.Commands.BookSeat;

public class BookSeatCommandValidator : AbstractValidator<BookSeatCommand>
{
    public BookSeatCommandValidator()
    {
        RuleFor(x => x.SeatId).NotEmpty();
        RuleFor(x => x.PassengerId).NotEmpty();
    }
}