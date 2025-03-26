using CheapFlights.Application.DTOs;
using CheapFlights.Domain.Models;

namespace CheapFlights.Application.Contracts;

public interface IFlightService
{
    Task<List<FlightResultDto>> GetFlights(FlightRequestDto request);
    Task<BookingResultDto> CreateBooking(BookingRequestDto request);
    Task<BookingResultDto> RetrieveBooking(RetrieveBookingRequestDto request);
}