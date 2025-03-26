using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using CheapFlights.Application.Contracts;
using CheapFlights.Application.DTOs;
using CheapFlights.Application.Implementation;
using CheapFlights.Domain.Contracts;
using CheapFlights.Domain.Models;
using Moq;

namespace CheapFlights.Tests.Integration;

[TestFixture]
public class FlightServiceIntegrationTest : IDisposable
{
    private readonly ServiceProvider _serviceProvider;
    private readonly Mock<IAvailabilityService> _availabilityServiceMock;
    private readonly Mock<IBookingService> _bookingServiceMock;
    private readonly IMapper _mapper;

    public FlightServiceIntegrationTest()
    {
        var serviceCollection = new ServiceCollection();

        // Configurar AutoMapper
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<PaxPrice, PaxPriceDto>().ReverseMap();
            cfg.CreateMap<PaxType, PaxTypeDto>().ReverseMap();
            cfg.CreateMap<Contact, ContactDto>().ReverseMap();
            cfg.CreateMap<Passenger, PassengerDto>().ReverseMap();
            cfg.CreateMap<BookingRequest, BookingRequestDto>().ReverseMap();
            cfg.CreateMap<BookingResult, BookingResultDto>().ReverseMap();
            cfg.CreateMap<FlightRequest, FlightRequestDto>().ReverseMap();
            cfg.CreateMap<FlightResult, FlightResultDto>().ReverseMap();
            cfg.CreateMap<RetrieveBookingRequest, RetrieveBookingRequestDto>().ReverseMap();
        });
        _mapper = mapperConfig.CreateMapper();
        serviceCollection.AddSingleton(_mapper);

        // Configurar mocks
        _availabilityServiceMock = new Mock<IAvailabilityService>();
        _bookingServiceMock = new Mock<IBookingService>();

        serviceCollection.AddSingleton(_availabilityServiceMock.Object);
        serviceCollection.AddSingleton(_bookingServiceMock.Object);

        // Configurar FlightService
        serviceCollection.AddTransient<IFlightService, FlightService>();

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    [OneTimeTearDown]
    public void Dispose()
    {
        _serviceProvider.Dispose();
    }

    [Test]
    public async Task CreateBooking_ShouldReturnBookingResult()
    {
        // Arrange
        var service = _serviceProvider.GetService<IFlightService>()!;
        var date = DateTime.Now;
        var request = new BookingRequestDto("11", new List<PassengerDto>(), new ContactDto("John", "Doe", "john.doe@example.com"));
        var bookingResult = new BookingResult(date, "BCN", "AMS", "1111", new List<Passenger>(), new Contact("John", "Doe", "john.doe@example.com"), date, "111111", 100);
        var expectedBookingResult = new BookingResultDto(date, "BCN", "AMS", "1111", new List<PassengerDto>(), new ContactDto("John", "Doe", "john.doe@example.com"), date, "111111", 100);

        _bookingServiceMock.Setup(x => x.CreateBooking(It.IsAny<BookingRequest>())).Returns(Task.FromResult(bookingResult));

        // Act
        var result = await service.CreateBooking(request);

        // Assert
        Assert.NotNull(result);
        //Assert.That(result, Is.EqualTo(expectedBookingResult));
    }

    [Test]
    public async Task GetFlights_ShouldReturnListOfFlightResults()
    {
        // Arrange
        var service = _serviceProvider.GetService<IFlightService>()!;
        var date = DateTime.Now;
        var request = new FlightRequestDto(date, "BCN", "AMS", new List<PaxTypeDto>
            {
                new PaxTypeDto("ADT", 1),
            });
        var flightResultList = new List<FlightResult>
            {
                new FlightResult("flightKey1", "1111", date, "BCN", "AMS", new List<PaxPrice>()),
                new FlightResult("flightKey2", "2222", date, "BCN", "AMS", new List<PaxPrice>())
            };
        var expectedFlightResultList = new List<FlightResultDto>
            {
                new FlightResultDto("flightKey1", "1111", date, "BCN", "AMS", new List<PaxPriceDto>()),
                new FlightResultDto("flightKey2", "2222", date, "BCN", "AMS", new List<PaxPriceDto>())
            };

        _availabilityServiceMock.Setup(x => x.GetFlights(It.IsAny<FlightRequest>())).Returns(Task.FromResult(flightResultList));

        // Act
        var result = await service.GetFlights(request);

        // Assert
        Assert.NotNull(result);
        Assert.That(result.Count, Is.EqualTo(expectedFlightResultList.Count));
        for (int i = 0; i < expectedFlightResultList.Count; i++)
        {
            Assert.That(result[i].FlightKey, Is.EqualTo(expectedFlightResultList[i].FlightKey));
        }
    }

    [Test]
    public async Task RetrieveBooking_ShouldReturnBookingResult()
    {
        // Arrange
        var service = _serviceProvider.GetService<IFlightService>()!;
        var date = DateTime.Now;
        var request = new RetrieveBookingRequestDto("BookingId", "john.doe@example.com");
        var bookingResult = new BookingResult(date, "BCN", "AMS", "FlightNumber", new List<Passenger>(), new Contact("John", "Doe", "john.doe@example.com"), date, "BookingId", 100);
        var expectedBookingResult = new BookingResultDto(date, "BCN", "AMS", "FlightNumber", new List<PassengerDto>(), new ContactDto("John", "Doe", "john.doe@example.com"), date, "BookingId", 100);

        _bookingServiceMock.Setup(x => x.RetrieveBooking(It.IsAny<RetrieveBookingRequest>())).Returns(Task.FromResult(bookingResult));

        // Act
        var result = await service.RetrieveBooking(request);

        // Assert
        Assert.NotNull(result);
        //Assert.That(result, Is.EqualTo(expectedBookingResult));
    }
}
