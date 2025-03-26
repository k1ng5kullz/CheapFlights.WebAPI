using System.ComponentModel.DataAnnotations;

namespace CheapFlights.Domain.Models;

public record FlightRequest(DateTime FlightDate, string Origin, string Destination, List<PaxType> PaxType)
{
    [Required(ErrorMessage = "La fecha de vuelo es obligatoria")]
    public DateTime FlightDate { get; init; } = FlightDate;
    [Required(ErrorMessage = "El origen es obligatorio")]
    public string Origin { get; init; } = Origin;
    public string Destination { get; init; } = Destination;
    [Required(ErrorMessage = "Se debe informar por lo menos un tipo de pasajero")]
    public List<PaxType> PaxType { get; init; } = PaxType;

}
