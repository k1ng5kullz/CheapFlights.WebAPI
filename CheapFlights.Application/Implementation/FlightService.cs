using AutoMapper;
using CheapFlights.Application.DTOs;
using CheapFlights.Application.Contracts;
using CheapFlights.Domain.Contracts;
using CheapFlights.Domain.Models;

namespace CheapFlights.Application.Implementation;

public class FlightService : IFlightService
{
    private readonly IAvailabilityService _availabilityService;
    private readonly IBookingService _bookingService;
    private readonly IMapper _mapper;

    public FlightService(IAvailabilityService availabilityService, IBookingService bookingService, IMapper mapper)
    {
        _availabilityService = availabilityService;
        _bookingService = bookingService;
        _mapper = mapper;
    }

    public async Task<BookingResultDto> CreateBooking(BookingRequestDto request)
    {
        var result = await _bookingService.CreateBooking(_mapper.Map<BookingRequest>(request));
        return _mapper.Map<BookingResultDto>(result);
    }

    public async Task<List<FlightResultDto>> GetFlights(FlightRequestDto request)
    {
        var flights = await _availabilityService.GetFlights(_mapper.Map<FlightRequest>(request));

        return flights.Select(_mapper.Map<FlightResultDto>).ToList();
    }

    public async Task<BookingResultDto> RetrieveBooking(RetrieveBookingRequestDto request)
    {
        var booking = await _bookingService.RetrieveBooking(_mapper.Map<RetrieveBookingRequest>(request));

        return _mapper.Map<BookingResultDto>(booking);
    }
}