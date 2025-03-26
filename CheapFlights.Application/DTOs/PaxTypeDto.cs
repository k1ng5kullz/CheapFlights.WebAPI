using System.ComponentModel.DataAnnotations;

namespace CheapFlights.Application.DTOs;

public class PaxTypeDto(string Type, int Quantity)
{
    [Required(ErrorMessage = "El tipo de pasajero es obligatorio")]
    public string Type { get; init; } = Type;
    [Required(ErrorMessage = "La cantidad de pasajeros es obligatoria")]
    public int Quantity { get; init; } = Quantity;
}