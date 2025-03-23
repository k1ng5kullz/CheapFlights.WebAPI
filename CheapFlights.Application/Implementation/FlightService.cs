using CheapFlights.Domain.Models;
using CheapFlights.Domain.Contracts;
using AutoMapper;
using CheapFlights.Domain.DTOs;

namespace CheapFlights.Application.Implementation
{
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

        public Task<BookingResult> RetrieveBookingAsync(RetrieveBookingRequest request)
        {
            throw new NotImplementedException();
        }

        async Task<BookingResult> IFlightService.CreateBookingAsync(BookingRequest request)
        {
            var result = await _bookingService.CreateBooking(_mapper.Map<BookingRequestDto>(request));
            return _mapper.Map<BookingResult>(result);
        }

        async Task<List<FlightResult>> IFlightService.GetFlightsAsync(FlightRequest request)
        {
            var flights = await _availabilityService.GetFlights(_mapper.Map<FlightRequestDto>(request));

            return flights.Select(_mapper.Map<FlightResult>).ToList();
        }

        Task<BookingResult> IFlightService.RetrieveBookingAsync(RetrieveBookingRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
