using CheapFlights.Application.Contracts;
using CheapFlights.Application.DTOs;
using CheapFlights.Infrastructure.Cache;
using CheapFlights.Infrastructure.Implementation;
using Moq;

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
        public void CreateBooking_ShouldReturnBooking()
        {
            // Arrange
            var passengers = new List<PassengerDto>
            {
                new PassengerDto("John", "Doe", new DateTime(1990, 1, 1))
            };
            var bookingRq = new BookingRequestDto("FL123", passengers,
                 new ContactDto("John", "Doe", "john.doe@example.com"));

            var flight = new FlightResultDto("FL123",
                "FL123",
                DateTime.UtcNow,
                "Origin",
                "Destination",
                    new List<PaxPriceDto> { new PaxPriceDto("ADT", 100), new PaxPriceDto("CHL", 100) }
                );

            _availabilityService.Setup(a => a.GetFlightByKey(It.IsAny<string>())).Returns(flight);

            // Act
            var result = _bookingService.CreateBooking(bookingRq);


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
        public void RetrieveBooking_ShouldReturnBooking()
        {
            // Arrange
            var retrieveBookingRq = new RetrieveBookingRequestDto("BK123", "john.doe@example.com");


            var booking = new BookingResultDto(DateTime.Today, "BCN", "AMS", "BK123", new List<PassengerDto> {
                new PassengerDto("John","Doe",new DateTime(1990,1,1))
            }, new ContactDto("John", "Doe", "john.doe@example.com"), DateTime.Today, "BK123", 100);

            _cacheService.Setup(c => c.RetrieveBooking(It.IsAny<RetrieveBookingRequestDto>())).Returns(booking);

            // Act
            var result = _bookingService.RetrieveBooking(retrieveBookingRq);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.BookingId, Is.EqualTo(retrieveBookingRq.BookingId));
            Assert.That(result.Contact.Email, Is.EqualTo(retrieveBookingRq.ContactEmail));
        }
    }
}
