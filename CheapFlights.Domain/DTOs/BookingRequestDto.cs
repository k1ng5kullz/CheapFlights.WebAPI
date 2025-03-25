namespace CheapFlights.Domain.DTOs;

public record BookingRequestDto(string FlightKey,
                                List<PassengerDto> Passengers,
                                ContactDto Contact);
