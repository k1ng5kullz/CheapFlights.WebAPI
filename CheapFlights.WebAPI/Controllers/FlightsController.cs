using Microsoft.AspNetCore.Mvc;
using CheapFlights.Application.Contracts;
using CheapFlights.Application.DTOs;

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
    public async Task<ActionResult<IEnumerable<FlightResultDto>>> GetFlightsAvailability(FlightRequestDto request)
    {
        var flights = await _flightService.GetFlights(request);
        return Ok(flights);
    }

    [HttpPost("booking")]
    public async Task<ActionResult<BookingResultDto>> CreateBooking(BookingRequestDto request)
    {
        var availability = await Task.Run(() => _flightService.CreateBooking(request));
        return Ok(availability);
    }

    [HttpGet("retrieve({bookingId}/{contactEmail}")]
    public async Task<ActionResult<BookingResultDto>> Retrieve(string bookingId, string contactEmail)
    {
        var booking = await Task.Run(() => _flightService.RetrieveBooking(new RetrieveBookingRequestDto(bookingId, contactEmail)));
        return Ok(booking);
    }

}
