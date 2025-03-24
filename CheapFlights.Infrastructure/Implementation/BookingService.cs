using CheapFlights.Infrastructure.Cache;
using CheapFlights.Domain.Contracts;
using CheapFlights.Domain.DTOs;

namespace CheapFlights.Infrastructure.Implementation;

public class BookingService : IBookingService
{
    private readonly IAvailabilityService _availabilityService;
    private readonly ICacheService _cacheService;


    public BookingService(IAvailabilityService availabilityService, ICacheService cacheService)
    {
        _availabilityService = availabilityService;
        _cacheService = cacheService;
    }

    public string RandomBookingId(int length)
    {
        Random random = new Random();

        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public BookingResultDto CreateBooking(BookingRequestDto request)
    {
        var flight = _availabilityService.GetFlightByKey(request.FlightKey);

        var booking = new BookingResultDto(flight.FlightDate,
            flight.Origin,
            flight.Destination,
            flight.FlightNumber,
            request.FirstNamePax1,
            request.LastNamePax1,
            request.DateOfBirthPax1,
            request.FirstNamePax2,
            request.LastNamePax2,
            request.DateOfBirthPax2,
            request.FirstNamePax3,
            request.LastNamePax3,
            request.DateOfBirthPax3,
            request.FirstNamePax4,
            request.LastNamePax4,
            request.DateOfBirthPax4,
            request.FirstNamePax5,
            request.LastNamePax5,
            request.DateOfBirthPax5,
            request.Contact,
            DateTime.UtcNow,
            RandomBookingId(6).ToUpper(),
            flight.PaxPrice.Sum(s => s.Price));

        _cacheService.AddBooking(booking);

        return booking;
    }

    public BookingResultDto RetrieveBooking(RetrieveBookingRequestDto request)
    {
        return _cacheService.RetrieveBooking(request);
    }
}
