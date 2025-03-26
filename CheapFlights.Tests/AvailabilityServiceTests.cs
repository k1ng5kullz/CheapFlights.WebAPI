using CheapFlights.Application.Contracts;
using CheapFlights.Application.DTOs;
using Moq;

namespace CheapFlights.Application.Implementation
{
    [TestFixture]
    public class AvailabilityServiceTests
    {

        private Mock<IAvailabilityService> _availabilityServiceMock;

        [SetUp]
        public void SetUp()
        {
            _availabilityServiceMock = new Mock<IAvailabilityService>();

        }

        private IAvailabilityService CreateService()
        {
            return _availabilityServiceMock.Object;
        }

        [Test]
        public void GetFlightByKey_ShouldReturnAFlight()
        {
            // Arrange
            var service = this.CreateService();
            string flightKey = "testKey";
            var expectedFlight = new FlightResultDto(flightKey, "", DateTime.Today, "", "", new List<PaxPriceDto>
            {
                new PaxPriceDto("ADT", 100),
                new PaxPriceDto("CHD", 50)
            });
            _availabilityServiceMock.Setup(x => x.GetFlightByKey(flightKey)).Returns(expectedFlight);

            // Act
            var result = service.GetFlightByKey(flightKey);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.FlightKey, Is.EqualTo(flightKey));
        }

        [Test]
        public void GetFlights_ShouldReturnTheListOfFlights()
        {
            // Arrange
            var service = this.CreateService();
            var flightRq = new FlightRequestDto(DateTime.Today, "NYC", "LAX", new List<PaxTypeDto>
            {
                new PaxTypeDto("ADT", 100),
                new PaxTypeDto("CHD", 50)
            }); ;
            var expectedFlights = new List<FlightResultDto>
            {
                new FlightResultDto("flight1","",DateTime.Now,"","",new List<PaxPriceDto>
                {
                    new PaxPriceDto("ADT", 100),
                    new PaxPriceDto("CHL", 100),
                }),
                new FlightResultDto("flight2","",DateTime.Now,"","",new List<PaxPriceDto>
                {
                    new PaxPriceDto("ADT", 100),
                    new PaxPriceDto("CHL", 100),
                }),
            };
            _availabilityServiceMock.Setup(x => x.GetFlights(flightRq)).Returns(expectedFlights);

            // Act
            var result = service.GetFlights(flightRq);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].FlightKey, Is.EqualTo("flight1"));
            Assert.That(result[1].FlightKey, Is.EqualTo("flight2"));
        }
    }
}
