using CheapFlights.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace CheapFlights.Application.DTOs;

public class BookingRequestDto(string FlightKey,
                                List<PassengerDto> Passengers,
                                ContactDto Contact)
{
    [Required(ErrorMessage = "El Id de vuelo es obligatorio")]
    public string FlightKey { get; init; } = FlightKey;
    [Required(ErrorMessage = "Se debe informar por lo menos un pasajero Adulto")]
    public List<PassengerDto> Passengers { get; init; } = Passengers;
    [Required(ErrorMessage = "Se debe informar la persona de contacto")]
    public ContactDto Contact { get; init; } = Contact;
}
