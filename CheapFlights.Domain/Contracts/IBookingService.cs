using CheapFlights.Domain.DTOs;
using CheapFlights.Domain.Models;

namespace CheapFlights.Domain.Contracts;

public interface IBookingService
{
    BookingResultDto CreateBooking(BookingRequestDto request);
    BookingResultDto RetrieveBooking(RetrieveBookingRequestDto request);
}
