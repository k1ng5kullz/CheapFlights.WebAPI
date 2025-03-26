namespace CheapFlights.Domain.Models;

public record FlightResult(string FlightKey, string FlightNumber, DateTime FlightDate, string Origin, string Destination, List<PaxPrice> PaxPrice)
{
    public List<PaxPrice> PaxPrice { get; set; } = PaxPrice;
}
