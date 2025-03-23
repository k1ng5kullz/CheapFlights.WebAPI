using CheapFlights.Domain.Contracts;
using CheapFlights.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapFlights.Application.Implementation;

public class BookingService : IBookingService
{
    public Task<BookingResultDto> CreateBooking(BookingRequestDto flightRq)
    {
        throw new NotImplementedException();
    }

    public Task<BookingResultDto> RetrieveBooking(RetrieveBookingRequestDto request)
    {
        throw new NotImplementedException();
    }
}
