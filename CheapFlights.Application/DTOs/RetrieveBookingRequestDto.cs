using System.ComponentModel.DataAnnotations;

namespace CheapFlights.Application.DTOs;

public record RetrieveBookingRequestDto(string BookingId, string ContactEmail)
{
    [Required(ErrorMessage = "El BookingId es obligatorio")]
    [StringLength(6, ErrorMessage = "El Booking id debe tener 6 carácteres")]
    public string BookingId { get; set; } = BookingId;
    [Required(ErrorMessage = "El e-mail de contacto es obligatorio")]
    public string ContactEmail { get; set; } = ContactEmail;
}

