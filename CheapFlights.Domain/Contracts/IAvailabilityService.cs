using CheapFlights.Domain.DTOs;

namespace CheapFlights.Domain.Contracts;

public interface IAvailabilityService
{
    Task<List<FlightResultDto>> GetFlights(FlightRequestDto
        flightRq);
    Task<FlightResultDto> GetFlightByKey(string flightKey);
}
