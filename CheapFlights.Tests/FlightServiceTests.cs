using AutoMapper;
using CheapFlights.Application.Contracts;
using CheapFlights.Application.DTOs;
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
            this._availabilityService = new Mock<IAvailabilityService>();
            this._bookingService = new Mock<IBookingService>();
            this._mapper = new Mock<IMapper>();
        }

        private FlightService CreateService(Mapper mapperConfig)
        {
            return new FlightService(
                _availabilityService.Object,
                _bookingService.Object,
                mapperConfig ?? _mapper.Object);
        }

        [Test]
        public void CreateBooking_ShouldReturnBookingResult()
        {
            // Arrange
            var service = this.CreateService(null);
            var date = DateTime.Now;
            var request = new BookingRequest("flightKey", new List<Passenger>(), new Contact("John", "Dow", ""));
            var bookingResultDto = new BookingResultDto(date, "Origin", "Destination", "FlightNumber", new List<PassengerDto>(), new ContactDto("", "", ""), date, "BookingId", 100);
            var expectedBookingResult = new BookingResult(date, "Origin", "Destination", "FlightNumber", new List<Passenger>(), new Contact("", "", ""), date, "BookingId", 100);

            _bookingService.Setup(x => x.CreateBooking(It.IsAny<BookingRequestDto>())).Returns(bookingResultDto);
            _mapper.Setup(m => m.Map<BookingResult>(bookingResultDto)).Returns(expectedBookingResult);

            // Act
            var result = service.CreateBooking(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(expectedBookingResult));
        }

        [Test]
        public void GetFlights_ShouldReturnListOfFlightResults()
        {
            // Arrange
            //var config = new MapperConfiguration(config =>
            //{
            //    config.CreateMap<Passenger, PassengerDto>().ReverseMap();
            //    config.CreateMap<Contact, ContactDto>().ReverseMap();
            //    config.CreateMap<BookingRequest, BookingRequestDto>().ReverseMap();
            //    config.CreateMap<BookingResult, BookingResultDto>().ReverseMap();
            //    config.CreateMap<PaxPrice, PaxPriceDto>().ReverseMap();
            //    config.CreateMap<FlightResult, FlightResultDto>().ReverseMap();
            //});
            //var mapper = new Mapper(config);
            var service = this.CreateService(null);
            var date = DateTime.Now;
            var request = new FlightRequest(date, "Origin", "Destination", new List<PaxType>
            {
                new PaxType("ADT", 1),
            });
            var flightResultDtoList = new List<FlightResultDto>
            {
                new FlightResultDto("flightKey1", "FlightNumber1", date, "Origin", "Destination", new List<PaxPriceDto>()),
                new FlightResultDto("flightKey2", "FlightNumber2", date, "Origin", "Destination", new List<PaxPriceDto>())
            };
            var expectedFlightResultList = new List<FlightResult>
            {
                new FlightResult("flightKey1", "FlightNumber1", date, "Origin", "Destination", new List<PaxPrice>()),
                new FlightResult("flightKey2", "FlightNumber2", date, "Origin", "Destination", new List<PaxPrice>())
            };

            _availabilityService.Setup(x => x.GetFlights(It.IsAny<FlightRequestDto>())).Returns(flightResultDtoList);
            for (int i = 0; i < flightResultDtoList.Count; i++)
            {
                _mapper.Setup(m => m.Map<FlightResult>(flightResultDtoList[i])).Returns(expectedFlightResultList[i]);
            }

            // Act
            var result = service.GetFlights(request);

            // Assert
            Assert.IsNotNull(result);
            for (int i = 0; i < expectedFlightResultList.Count - 1; i++)
            {
                Assert.That(result[i], Is.EqualTo(expectedFlightResultList[i]));
            }
        }

        [Test]
        public void RetrieveBooking_ShouldReturnBookingResult()
        {
            // Arrange
            var service = this.CreateService(null);
            var date = DateTime.Now;
            var request = new RetrieveBookingRequest("BookingId", "");
            var bookingResultDto = new BookingResultDto(date, "Origin", "Destination", "FlightNumber", new List<PassengerDto>(), new ContactDto("", "", ""), date, "BookingId", 100);
            var expectedBookingResult = new BookingResult(date, "Origin", "Destination", "FlightNumber", new List<Passenger>(), new Contact("", "", ""), date, "BookingId", 100);

            _bookingService.Setup(x => x.RetrieveBooking(It.IsAny<RetrieveBookingRequestDto>())).Returns(bookingResultDto);
            _mapper.Setup(m => m.Map<BookingResult>(bookingResultDto)).Returns(expectedBookingResult);

            // Act
            var result = service.RetrieveBooking(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(expectedBookingResult));
        }
    }
}
