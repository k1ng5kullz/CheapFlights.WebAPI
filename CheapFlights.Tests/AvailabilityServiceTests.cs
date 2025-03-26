using CheapFlights.Domain.Models;
using CheapFlights.Domain.Contracts;
using CheapFlights.Domain.Constants;
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
        public async Task GetFlightByKey_ShouldReturnAFlight()
        {
            // Arrange
            var service = this.CreateService();
            string flightKey = "testKey";
            var expectedFlight = new FlightResult(flightKey, "", DateTime.Today, "", "", new List<PaxPrice>
            {
                new PaxPrice(PassengerType.Adult, 100),
                new PaxPrice(PassengerType.Child, 50)
            });
            _availabilityServiceMock.Setup(x => x.GetFlightByKey(flightKey)).Returns(Task.FromResult(expectedFlight));

            // Act
            var result = await service.GetFlightByKey(flightKey);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.FlightKey, Is.EqualTo(flightKey));
        }

        [Test]
        public async Task GetFlights_ShouldReturnTheListOfFlights()
        {
            // Arrange
            var service = this.CreateService();
            var flightRq = new FlightRequest(DateTime.Today, "NYC", "LAX", new List<PaxType>
            {
                new PaxType(PassengerType.Adult, 100),
                new PaxType(PassengerType.Child, 50)
            }); ;
            var expectedFlights = new List<FlightResult>
            {
                new FlightResult("flight1","",DateTime.Now,"","",new List<PaxPrice>
                {
                    new PaxPrice(PassengerType.Adult, 100),
                    new PaxPrice(PassengerType.Child, 100),
                }),
                new FlightResult("flight2","",DateTime.Now,"","",new List<PaxPrice>
                {
                    new PaxPrice(PassengerType.Adult, 100),
                    new PaxPrice(PassengerType.Child, 100),
                }),
            };
            _availabilityServiceMock.Setup(x => x.GetFlights(flightRq)).Returns(Task.FromResult(expectedFlights));

            // Act
            var result = await service.GetFlights(flightRq);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].FlightKey, Is.EqualTo("flight1"));
            Assert.That(result[1].FlightKey, Is.EqualTo("flight2"));
        }
    }
}
