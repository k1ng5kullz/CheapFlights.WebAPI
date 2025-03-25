namespace CheapFlights.Domain.Models;
public record BookingRequest(string FlightKey,
                             List<Passenger> Passengers,
                             Contact Contact);
