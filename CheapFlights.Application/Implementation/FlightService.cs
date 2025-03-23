using CheapFlights.Domain.Models;
using CheapFlights.Domain.Contracts;

namespace CheapFlights.Application.Implementation
{
    public class FlightService : IFlightService
    {
        private readonly IAvailabilityService _availabilityService;
        private readonly IBookingService _bookingService;

        public FlightService(IAvailabilityService availabilityService, IBookingService bookingService)
        {
            _availabilityService = availabilityService;
            _bookingService = bookingService;
        }

        Task<BookingResult> IFlightService.CheckAvailabilityAsync(BookingRequest request)
        {
            throw new NotImplementedException();
        }

        Task<FlightResult> IFlightService.GetFlightsAsync(FlightRequest request)
        {
            throw new NotImplementedException();
        }

        Task<BookingResult> IFlightService.RetrieveBookingAsync(string bookingId, string contactEmail)
        {
            throw new NotImplementedException();
        }
    }
}
