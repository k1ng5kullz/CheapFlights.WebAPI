using CheapFlights.Domain.DTOs;

namespace CheapFlights.Domain.Contracts;

public interface IAvailabilityService
{
    List<FlightDto> GetFlights(FlightRequestDto
        flightRq);
    FlightDto GetFlightByKey(string flightKey);
}
