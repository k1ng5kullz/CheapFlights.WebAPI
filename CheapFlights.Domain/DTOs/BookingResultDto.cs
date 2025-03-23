namespace CheapFlights.Domain.DTOs;

public record BookingResultDto(DateTime FlightDate, string Origin, string Destination, string FlightNumber, string FirstNamePax1, string LastNamePax1, DateTime DateOfBirthPax1, string FirstNamePax2, string LastNamePax2, DateTime DateOfBirthPax2, string FirstNamePax3, string LastNamePax3, DateTime DateOfBirthPax3, string FirstNamePax4, string LastNamePax4, DateTime DateOfBirthPax4, string FirstNamePax5, string LastNamePax5, DateTime DateOfBirthPax5, ContactDto Contact, DateTime BookingDate, string BookingId, decimal TotalPrice)
{
    public decimal TotalPrice { get; set; } = TotalPrice;
}
