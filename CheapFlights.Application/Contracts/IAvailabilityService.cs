using CheapFlights.Application.DTOs;

namespace CheapFlights.Application.Contracts;

public interface IAvailabilityService
{
    List<FlightResultDto> GetFlights(FlightRequestDto
        flightRq);
    FlightResultDto GetFlightByKey(string flightKey);
}
