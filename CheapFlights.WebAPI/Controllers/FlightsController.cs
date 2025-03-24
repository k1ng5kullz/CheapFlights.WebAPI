using Microsoft.AspNetCore.Mvc;
using CheapFlights.Domain.Models;
using CheapFlights.Domain.Contracts;

namespace CheapFlights.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FlightsController : ControllerBase
{
    private readonly IFlightService _flightService;

    public FlightsController(IFlightService flightService)
    {
        _flightService = flightService;
    }

    [HttpPost("availability")]
    public async Task<ActionResult<IEnumerable<FlightResult>>> Get(FlightRequest request)
    {
        var flights = await Task.Run(() => _flightService.GetFlights(request));
        return Ok(flights);
    }

    [HttpPost("booking")]
    public async Task<ActionResult<BookingResult>> Availability(BookingRequest request)
    {
        var availability = await Task.Run(() => _flightService.CreateBooking(request));
        return Ok(availability);
    }

    [HttpGet("retrieve({bookingId}/{contactEmail}")]
    public async Task<ActionResult<BookingResult>> Retrieve(string bookingId, string contactEmail)
    {
        var booking = await Task.Run(() => _flightService.RetrieveBooking(new RetrieveBookingRequest(bookingId, contactEmail)));
        return Ok(booking);
    }

}
