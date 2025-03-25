namespace CheapFlights.Application.DTOs;

public record BookingResultDto(DateTime FlightDate,
                               string Origin,
                               string Destination,
                               string FlightNumber,
                               List<PassengerDto> Passengers,
                               ContactDto Contact,
                               DateTime BookingDate,
                               string BookingId,
                               decimal TotalPrice)
{
    public decimal TotalPrice { get; set; } = TotalPrice;
}
