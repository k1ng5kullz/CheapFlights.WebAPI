namespace CheapFlights.Domain.Models;

public record FlightResult(string FlightKey, string FlightNumber, DateTime FlightDate, string Origin, string Destination, List<PaxPrice> PaxPrice)
{
    List<PaxPrice> PaxPrice { get; init; } = PaxPrice;
}
