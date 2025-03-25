namespace CheapFlights.Domain.Models;

public record BookingResult(DateTime FlightDate,
                            string Origin,
                            string Destination,
                            string FlightNumber,
                            List<Passenger> Passengers,
                            Contact Contact,
                            DateTime BookingDate,
                            string BookingId,
                            decimal TotalPrice);
