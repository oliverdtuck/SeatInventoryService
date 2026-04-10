using FluentValidation;

namespace SeatInventoryService.Application.Queries.GetSeatsByFlight;

public class GetSeatsByFlightQueryValidator : AbstractValidator<GetSeatsByFlightQuery>
{
    public GetSeatsByFlightQueryValidator()
    {
        RuleFor(x => x.FlightId).NotEmpty();
    }
}