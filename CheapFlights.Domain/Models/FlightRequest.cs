namespace CheapFlights.Domain.Models;

public record FlightRequest(DateTime FlightDate, string Origin, string Destination, List<PaxType> PaxType);
