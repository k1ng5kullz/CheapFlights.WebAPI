using CheapFlights.Domain.Models;

namespace CheapFlights.Infrastructure.Cache;

public interface ICacheService
{
    BookingResult RetrieveBooking(RetrieveBookingRequest retrieveBookingRq);
    void AddBooking(BookingResult bookingRs);
}
