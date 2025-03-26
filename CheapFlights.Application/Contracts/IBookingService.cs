using CheapFlights.Application.DTOs;

namespace CheapFlights.Application.Contracts;

public interface IBookingService
{
    Task<BookingResultDto> CreateBooking(BookingRequestDto request);
    Task<BookingResultDto> RetrieveBooking(RetrieveBookingRequestDto request);
}
