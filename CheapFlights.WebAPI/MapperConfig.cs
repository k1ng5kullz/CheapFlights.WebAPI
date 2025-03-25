using AutoMapper;
using CheapFlights.Application.DTOs;
using CheapFlights.Domain.Models;

namespace CheapFlights.WebAPI.Mapper;

public class CheapFlightsProfile : Profile
{
    public CheapFlightsProfile()
    {
        CreateMap<PaxPrice, PaxPriceDto>().ReverseMap();
        CreateMap<PaxType, PaxTypeDto>().ReverseMap();
        CreateMap<Contact, ContactDto>().ReverseMap();
        CreateMap<Passenger, PassengerDto>().ReverseMap();
        CreateMap<RetrieveBookingRequest, RetrieveBookingRequestDto>().ReverseMap();
        CreateMap<BookingRequest, BookingRequestDto>().ReverseMap();
        CreateMap<BookingResult, BookingResultDto>().ReverseMap();
        CreateMap<FlightRequest, FlightRequestDto>().ReverseMap();
        CreateMap<FlightResult, FlightResultDto>().ReverseMap();
    }
}

