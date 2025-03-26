using System.ComponentModel.DataAnnotations;

namespace CheapFlights.Domain.Models;

public class Contact(string FirstName, string LastName, string Email)
{
    [Required(ErrorMessage = "El nombre del contacto es obligatorio")]
    public string FirstName { get; init; } = FirstName;
    [Required(ErrorMessage = "El apellido del contacto es obligatorio")]
    public string LastName { get; init; } = LastName;
    [Required(ErrorMessage = "El email del contacto es obligatorio")]
    public string Email { get; init; } = Email;
}
