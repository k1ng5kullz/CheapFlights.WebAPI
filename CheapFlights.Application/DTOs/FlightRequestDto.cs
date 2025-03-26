using CheapFlights.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace CheapFlights.Application.DTOs;

public record FlightRequestDto(DateTime FlightDate, string Origin, string Destination, List<PaxTypeDto> PaxType)
{
    [Required(ErrorMessage = "La fecha de vuelo es obligatoria")]
    public DateTime FlightDate { get; init; } = FlightDate;
    [Required(ErrorMessage = "El origen es obligatorio")]
    public string Origin { get; init; } = Origin;
    public string Destination { get; init; } = Destination;
    [Required(ErrorMessage = "Se debe informar por lo menos un tipo de pasajero")]
    public List<PaxTypeDto> PaxType { get; init; } = PaxType;

}
