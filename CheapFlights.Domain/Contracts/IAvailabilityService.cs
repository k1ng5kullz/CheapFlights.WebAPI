using CheapFlights.Domain.Models;

namespace CheapFlights.Domain.Contracts;

public interface IAvailabilityService
{
    Task<List<FlightResult>> GetFlights(FlightRequest
        flightRq);
    Task<FlightResult> GetFlightByKey(string flightKey);
}
