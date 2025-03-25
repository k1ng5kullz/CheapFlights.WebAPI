namespace CheapFlights.Application.DTOs;

public record FlightRequestDto(DateTime FlightDate, string Origin, string Destination, List<PaxTypeDto> PaxType);
