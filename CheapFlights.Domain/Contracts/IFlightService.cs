using CheapFlights.Domain.Models;

namespace CheapFlights.Domain.Contracts;

public interface IFlightService
{
    Task<List<FlightResult>> GetFlightsAsync(FlightRequest request);
    Task<BookingResult> CreateBookingAsync(BookingRequest request);
    Task<BookingResult> RetrieveBookingAsync(RetrieveBookingRequest request);
}