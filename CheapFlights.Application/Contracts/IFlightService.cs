using CheapFlights.Application.Models;

namespace CheapFlights.Application.Contracts;

public interface IFlightService
{
    Task<FlightResult> GetFlightsAsync(FlightRequest request);
    Task<BookingResult> CheckAvailabilityAsync(BookingRequest request);
    Task<BookingResult> RetrieveBookingAsync(string bookingId, string contactEmail);
}