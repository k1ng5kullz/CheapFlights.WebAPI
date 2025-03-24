using CheapFlights.Domain.DTOs;

namespace CheapFlights.Domain.Contracts;

public interface IAvailabilityService
{
    List<FlightResultDto> GetFlights(FlightRequestDto
        flightRq);
    FlightResultDto GetFlightByKey(string flightKey);
}
