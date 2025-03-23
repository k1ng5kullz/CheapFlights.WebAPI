using CheapFlights.Domain.DTOs;

namespace CheapFlights.Domain.Contracts;

public interface IBookingService
{
    List<FlightDto> GetFlights(FlightRequestDto flightRq);
    FlightDto GetFlightByKey(string flightKey);
}
