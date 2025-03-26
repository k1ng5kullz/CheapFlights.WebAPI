using CheapFlights.Domain.Contracts;
using CheapFlights.Domain.Constants;
using CheapFlights.Infrastructure.Cache;
using CheapFlights.Infrastructure.Implementation;
using Moq;
using CheapFlights.Domain.Models;

namespace CheapFlights.Application.Implementation
{
    [TestFixture]
    public class BookingServiceTests
    {
        private Mock<ICacheService> _cacheService;
        private Mock<IAvailabilityService> _availabilityService;
        private IBookingService _bookingService;

        [SetUp]
        public void SetUp()
        {
            _availabilityService = new Mock<IAvailabilityService>();
            _cacheService = new Mock<ICacheService>();
            _bookingService = new BookingService(_availabilityService.Object, _cacheService.Object);
        }

        [Test]
        public async Task CreateBooking_ShouldReturnBooking()
        {
            // Arrange
            var passengers = new List<Passenger>
            {
                new Passenger("John", "Doe", new DateTime(1990, 1, 1))
            };
            var bookingRq = new BookingRequest("FL123", passengers,
                 new Contact("John", "Doe", "john.doe@example.com"));

            var flight = new FlightResult("FL123",
                "FL123",
                DateTime.UtcNow,
                "Origin",
                "Destination",
                    new List<PaxPrice> { new PaxPrice(PassengerType.Adult, 100), new PaxPrice(PassengerType.Child, 100) }
                );

            _availabilityService.Setup(a => a.GetFlightByKey(It.IsAny<string>())).Returns(Task.FromResult(flight));

            // Act
            var result = await _bookingService.CreateBooking(bookingRq);


            // Assert
            var passenger = result.Passengers.First();
            var resultPassenger = result.Passengers.First();
            Assert.NotNull(result);
            Assert.That(resultPassenger.FirstName, Is.EqualTo(passenger.FirstName));
            Assert.That(resultPassenger.LastName, Is.EqualTo(passenger.LastName));
            Assert.That(resultPassenger.DateOfBirth, Is.EqualTo(passenger.DateOfBirth));
            Assert.That(result.Contact, Is.EqualTo(bookingRq.Contact));
            Assert.That(result.FlightNumber, Is.EqualTo(flight.FlightNumber));
            Assert.That(result.Origin, Is.EqualTo(flight.Origin));
            Assert.That(result.Destination, Is.EqualTo(flight.Destination));
            Assert.That(result.FlightDate, Is.EqualTo(flight.FlightDate));
            Assert.That(result.TotalPrice, Is.EqualTo(100));
        }

        [Test]
        public async Task RetrieveBooking_ShouldReturnBooking()
        {
            // Arrange
            var retrieveBookingRq = new RetrieveBookingRequest("BK123", "john.doe@example.com");


            var booking = new BookingResult(DateTime.Today, "BCN", "AMS", "BK123", new List<Passenger> {
                new Passenger("John","Doe",new DateTime(1990,1,1))
            }, new Contact("John", "Doe", "john.doe@example.com"), DateTime.Today, "BK123", 100);

            _cacheService.Setup(c => c.RetrieveBooking(It.IsAny<RetrieveBookingRequest>())).Returns(booking);

            // Act
            var result = await _bookingService.RetrieveBooking(retrieveBookingRq);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.BookingId, Is.EqualTo(retrieveBookingRq.BookingId));
            Assert.That(result.Contact.Email, Is.EqualTo(retrieveBookingRq.ContactEmail));
        }
    }
}
