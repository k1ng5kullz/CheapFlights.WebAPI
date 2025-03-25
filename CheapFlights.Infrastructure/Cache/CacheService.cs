using CheapFlights.Application.DTOs;
using System.Diagnostics;
using System.Runtime.Caching;

namespace CheapFlights.Infrastructure.Cache
{
    public class CacheService : ICacheService
    {
        public static MemoryCache Cache { get; set; }

        public CacheService()
        {
            Cache = new MemoryCache("BookingCache");
        }

        public BookingResultDto RetrieveBooking(RetrieveBookingRequestDto request)
        {
            BookingResultDto? result = default;
            try
            {
                var key = $"{request.BookingId}{request.ContactEmail}";
                CacheRepository.TryGet<BookingResultDto>(Cache, key, out result);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }

            return result!;
        }


        public void AddBooking(BookingResultDto bookingRs)
        {
            try
            {
                var key = $"{bookingRs.BookingId}{bookingRs.Contact.Email}";
                CacheRepository.Add(Cache, key, bookingRs, new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTime.UtcNow.AddDays(1)
                });
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }

        }
    }
}
