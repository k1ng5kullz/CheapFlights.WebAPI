using CheapFlights.Domain.Models;

namespace CheapFlights.Domain.Contracts;

public interface IFlightService
{
    Task<List<FlightResult>> GetFlights(FlightRequest request);
    Task<BookingResult> CreateBooking(BookingRequest request);
    Task<BookingResult> RetrieveBooking(RetrieveBookingRequest request);
}