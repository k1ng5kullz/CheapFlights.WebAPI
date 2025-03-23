using CheapFlights.Domain.DTOs;
using CheapFlights.Domain.Models;

namespace CheapFlights.Domain.Contracts;

public interface IBookingService
{
    Task<BookingResultDto> CreateBooking(BookingRequestDto request);
    Task<BookingResultDto> RetrieveBooking(RetrieveBookingRequestDto request);
}
