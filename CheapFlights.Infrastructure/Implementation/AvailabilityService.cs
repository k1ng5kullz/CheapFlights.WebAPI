using CheapFlights.Application.DTOs;
using CheapFlights.Domain.Contracts;
using Newtonsoft.Json;
using System.Reflection;
using CheapFlights.Domain.Constants;
using CheapFlights.Domain.Models;

namespace CheapFlights.Infrastructure.Implementation;

public class AvailabilityService : IAvailabilityService
{
    private List<FlightResult>? _flights;

    public AvailabilityService()
    {
        LoadFlights();
    }

    private void LoadFlights()
    {
        var assembly = Assembly.GetExecutingAssembly();

        var fileSettings = ".data.flights.json";

        var pathConfigfile = string.Concat(assembly.GetName().Name, fileSettings);
        _flights = JsonConvert.DeserializeObject<List<FlightResult>>(GetAssemblyFile(pathConfigfile));
    }

    private static string GetAssemblyFile(string resource)
    {
        var _executingAssembly = Assembly.GetExecutingAssembly();
        using (var stream = _executingAssembly.GetManifestResourceStream(resource))
        {

            if (stream != null)
            {
                var reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
        }
        return null!;
    }

    public Task<FlightResult> GetFlightByKey(string flightKey)
    {
        return Task.FromResult(_flights!.FirstOrDefault(w => w.FlightKey == flightKey, default!));
    }

    public Task<List<FlightResult>> GetFlights(FlightRequest flightRq)
    {
        var flig = _flights!.Where(w => w.FlightDate.Date == flightRq.FlightDate.Date && 
        flightRq.Origin == w.Origin && 
        (flightRq.Destination != string.Empty ? w.Destination == flightRq.Destination : true)).ToList();

        return Task.FromResult(flig);
    }
}
