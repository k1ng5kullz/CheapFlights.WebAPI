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

        int adults = request.Passengers.Count(passenger => (DateTime.Today.Year - passenger.DateOfBirth.Year) > 16 && passenger.FirstName != string.Empty);
        int childs = request.Passengers.Count(passenger => (DateTime.Today.Year - passenger.DateOfBirth.Year) < 16 && passenger.FirstName != string.Empty);

        decimal price = (adults * flight.PaxPrice[0].Price) + (childs * flight.PaxPrice[1].Price);

        var booking = new BookingResultDto(flight.FlightDate,
            flight.Origin,
            flight.Destination,
            flight.FlightNumber,
            request.Passengers,
            request.Contact,
            DateTime.UtcNow,
            RandomBookingId(6).ToUpper(),
            price);

        _cacheService.AddBooking(booking);

        return booking;
    }

    public BookingResultDto RetrieveBooking(RetrieveBookingRequestDto request)
    {
        return _cacheService.RetrieveBooking(request);
    }
}
