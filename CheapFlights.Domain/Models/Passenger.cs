using CheapFlights.Domain.Constants;

namespace CheapFlights.Domain.Models;

public record Passenger(string FirstName, string LastName, DateTime DateOfBirth)
{
    public string Type { get; } = (DateTime.Today.Year - DateOfBirth.Year) > 16 ? PassengerType.Adult : PassengerType.Child;
}