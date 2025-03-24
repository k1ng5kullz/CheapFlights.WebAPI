using CheapFlights.Domain.Models;

namespace CheapFlights.Domain.Contracts;

public interface IFlightService
{
    List<FlightResult> GetFlights(FlightRequest request);
    BookingResult CreateBooking(BookingRequest request);
    BookingResult RetrieveBooking(RetrieveBookingRequest request);
}