using CheapFlights.Application.Models;
using CheapFlights.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheapFlights.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FlightsController : ControllerBase
{
    private readonly IFlightService _flightService;

    FlightsController(IFlightService flightService)
    {
        _flightService = flightService;
    }

    [HttpPost(Name = "availability")]
    public async Task<ActionResult<IEnumerable<FlightResult>>> Get(FlightRequest request)
    {
        var flights = await _flightService.GetFlightsAsync(request);
        return Ok(flights);
    }

    [HttpPost(Name = "booking")]
    public async Task<ActionResult<BookingResult>> Availability(BookingRequest request)
    {
        var availability = await _flightService.CheckAvailabilityAsync(request);
        return Ok(availability);
    }

    [HttpGet(Name = "retrieve({bookingId}/{contactEmail}")]
    public async Task<ActionResult<BookingResult>> Retrieve(string bookingId, string contactEmail)
    {
        var booking = await _flightService.RetrieveBookingAsync(bookingId, contactEmail);
        return Ok(booking);
    }

}
