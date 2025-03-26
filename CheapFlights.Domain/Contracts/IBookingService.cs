using CheapFlights.Domain.Models;

namespace CheapFlights.Domain.Contracts;

public interface IBookingService
{
    Task<BookingResult> CreateBooking(BookingRequest request);
    Task<BookingResult> RetrieveBooking(RetrieveBookingRequest request);
}
