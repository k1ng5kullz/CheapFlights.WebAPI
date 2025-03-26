using CheapFlights.Application.DTOs;

namespace CheapFlights.Application.Contracts;

public interface IAvailabilityService
{
    Task<List<FlightResultDto>> GetFlights(FlightRequestDto
        flightRq);
    Task<FlightResultDto> GetFlightByKey(string flightKey);
}
