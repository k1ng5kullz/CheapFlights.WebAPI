using CheapFlights.Domain.Models;
using CheapFlights.Domain.Contracts;
using AutoMapper;
using CheapFlights.Application.DTOs;
using CheapFlights.Application.Contracts;

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

    public async Task<BookingResult> CreateBooking(BookingRequest request)
    {
        var result = await _bookingService.CreateBooking(_mapper.Map<BookingRequestDto>(request));
        return _mapper.Map<BookingResult>(result);
    }

    public async Task<List<FlightResult>> GetFlights(FlightRequest request)
    {
        var flights = await _availabilityService.GetFlights(_mapper.Map<FlightRequestDto>(request));

        return flights.Select(_mapper.Map<FlightResult>).ToList();
    }

    public async Task<BookingResult> RetrieveBooking(RetrieveBookingRequest request)
    {
        var booking = await _bookingService.RetrieveBooking(_mapper.Map<RetrieveBookingRequestDto>(request));

        return _mapper.Map<BookingResult>(booking);
    }
}