using AutoMapper;
using CheapFlights.Application.DTOs;
using CheapFlights.Domain.Constants;
using CheapFlights.Domain.Contracts;
using CheapFlights.Domain.Models;
using Moq;

namespace CheapFlights.Application.Implementation
{
    [TestFixture]
    public class FlightServiceTests
    {
        private Mock<IAvailabilityService> _availabilityService;
        private Mock<IBookingService> _bookingService;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void SetUp()
        {
            _availabilityService = new Mock<IAvailabilityService>();
            _bookingService = new Mock<IBookingService>();
            _mapper = new Mock<IMapper>();
        }

        private FlightService CreateService()
        {
            return new FlightService(
                _availabilityService.Object,
                _bookingService.Object,
                _mapper.Object);
        }

        [Test]
        public async Task CreateBooking_ShouldReturnBookingResult()
        {
            // Arrange
            var service = CreateService();
            var date = DateTime.Now;
            var request = new BookingRequestDto("11", new List<PassengerDto>(), new ContactDto("John", "Dow", ""));
            var bookingResult = new BookingResult(date, "Origin", "Destination", "FlightNumber", new List<Passenger>(), new Contact("", "", ""), date, "BookingId", 100);
            var expectedBookingResult = new BookingResultDto(date, "Origin", "Destination", "FlightNumber", new List<PassengerDto>(), new ContactDto("", "", ""), date, "BookingId", 100);

            _bookingService.Setup(x => x.CreateBooking(It.IsAny<BookingRequest>())).Returns(Task.FromResult(bookingResult));
            _mapper.Setup(m => m.Map<BookingResultDto>(bookingResult)).Returns(expectedBookingResult);

            // Act
            var result = await service.CreateBooking(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(expectedBookingResult));
        }

        [Test]
        public async Task GetFlights_ShouldReturnListOfFlightResults()
        {
            // Arrange         
            var service = CreateService();
            var date = DateTime.Now;
            var request = new FlightRequestDto(date, "Origin", "Destination", new List<PaxTypeDto>
            {
                new PaxTypeDto(PassengerType.Adult, 1),
            });
            var flightResultList = new List<FlightResult>
            {
                new FlightResult("flightKey1", "FlightNumber1", date, "Origin", "Destination", new List<PaxPrice>()),
                new FlightResult("flightKey2", "FlightNumber2", date, "Origin", "Destination", new List<PaxPrice>())
            };
            var expectedFlightResultList = new List<FlightResultDto>
            {
                new FlightResultDto("flightKey1", "FlightNumber1", date, "Origin", "Destination", new List<PaxPriceDto>()),
                new FlightResultDto("flightKey2", "FlightNumber2", date, "Origin", "Destination", new List<PaxPriceDto>())
            };

            _availabilityService.Setup(x => x.GetFlights(It.IsAny<FlightRequest>())).Returns(Task.FromResult(flightResultList));
            for (int i = 0; i < flightResultList.Count; i++)
            {
                _mapper.Setup(m => m.Map<FlightResultDto>(flightResultList[i])).Returns(expectedFlightResultList[i]);
            }

            // Act
            var result = await service.GetFlights(request);

            // Assert
            Assert.IsNotNull(result);
            for (int i = 0; i < expectedFlightResultList.Count - 1; i++)
            {
                Assert.That(result[i], Is.EqualTo(expectedFlightResultList[i]));
            }
        }

        [Test]
        public async Task RetrieveBooking_ShouldReturnBookingResult()
        {
            // Arrange
            var service = CreateService();
            var date = DateTime.Now;
            var request = new RetrieveBookingRequestDto("BookingId", "");
            var bookingResult = new BookingResult(date, "Origin", "Destination", "FlightNumber", new List<Passenger>(), new Contact("", "", ""), date, "BookingId", 100);
            var expectedBookingResult = new BookingResultDto(date, "Origin", "Destination", "FlightNumber", new List<PassengerDto>(), new ContactDto("", "", ""), date, "BookingId", 100);

            _bookingService.Setup(x => x.RetrieveBooking(It.IsAny<RetrieveBookingRequest>())).Returns(Task.FromResult(bookingResult));
            _mapper.Setup(m => m.Map<BookingResultDto>(bookingResult)).Returns(expectedBookingResult);

            // Act
            var result = await service.RetrieveBooking(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(expectedBookingResult));
        }
    }
}
