using CheapFlights.Domain.Contracts;
using CheapFlights.Domain.DTOs;

namespace CheapFlights.Application.Implementation;

public class AvailabilityService : IAvailabilityService
{
    public Task<FlightResultDto> GetFlightByKey(string flightKey)
    {
        throw new NotImplementedException();
    }

    public Task<List<FlightResultDto>> GetFlights(FlightRequestDto flightRq)
    {
        throw new NotImplementedException();
    }
}
