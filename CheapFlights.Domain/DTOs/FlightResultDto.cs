namespace CheapFlights.Domain.DTOs;

public record FlightResultDto(string FlightKey, string FlightNumber, DateTime FlightDate, string Origin, string Destination, List<PaxPriceDto> PaxPrice)
{
    public List<PaxPriceDto> PaxPrice { get; set; } = PaxPrice;
}

