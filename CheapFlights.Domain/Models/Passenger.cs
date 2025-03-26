using System.ComponentModel.DataAnnotations;

namespace CheapFlights.Domain.Models;

public class Passenger(string FirstName, string LastName, DateTime DateOfBirth)
{
    [Required(ErrorMessage = "El nombre del pasajero es obligatorio")]
    public string FirstName { get; init; } = FirstName;
    [Required(ErrorMessage = "El apellido del pasajero es obligatorio")]
    public string LastName { get; init; } = LastName;
    [Required(ErrorMessage = "La fecha de nacimiento del pasajero es obligatoria")]
    public DateTime DateOfBirth { get; init; } = DateOfBirth;
}

