namespace CheapFlights.Application.DTOs;

public record BookingRequestDto(string FlightKey,
                                List<PassengerDto> Passengers,
                                ContactDto Contact);
