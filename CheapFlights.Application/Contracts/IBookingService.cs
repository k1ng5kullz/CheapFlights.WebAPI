using CheapFlights.Application.DTOs;

namespace CheapFlights.Application.Contracts;

public interface IBookingService
{
    BookingResultDto CreateBooking(BookingRequestDto request);
    BookingResultDto RetrieveBooking(RetrieveBookingRequestDto request);
}
