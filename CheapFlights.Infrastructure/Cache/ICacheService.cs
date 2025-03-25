using CheapFlights.Application.DTOs;

namespace CheapFlights.Infrastructure.Cache;

public interface ICacheService
{
    BookingResultDto RetrieveBooking(RetrieveBookingRequestDto retrieveBookingRq);
    void AddBooking(BookingResultDto bookingRs);
}
