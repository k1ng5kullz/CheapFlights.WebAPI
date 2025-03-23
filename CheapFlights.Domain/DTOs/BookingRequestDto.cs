namespace CheapFlights.Domain.DTOs;

public record BookingRequestDto(string FlightKey, string FirstNamePax1, string LastNamePax1, DateTime DateOfBirthPax1, string FirstNamePax2, string LastNamePax2, DateTime DateOfBirthPax2, string FirstNamePax3, string LastNamePax3, DateTime DateOfBirthPax3, string FirstNamePax4, string LastNamePax4, DateTime DateOfBirthPax4, string FirstNamePax5, string LastNamePax5, DateTime DateOfBirthPax5, ContactDto Contact);
