using CheapFlights.Application.DTOs;
using CheapFlights.Application.Contracts;
using Newtonsoft.Json;
using System.Reflection;

namespace CheapFlights.Infrastructure.Implementation;

public class AvailabilityService : IAvailabilityService
{
    private List<FlightResultDto> _flights;

    public AvailabilityService()
    {
        LoadFlights();
    }

    private void LoadFlights()
    {
        var assembly = Assembly.GetExecutingAssembly();

        var fileSettings = ".data.flights.json";

        var pathConfigfile = string.Concat(assembly.GetName().Name, fileSettings);
        _flights = JsonConvert.DeserializeObject<List<FlightResultDto>>(GetAssemblyFile(pathConfigfile));
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
        return null;
    }

    public FlightResultDto GetFlightByKey(string flightKey)
    {
        return _flights.FirstOrDefault(w => w.FlightKey == flightKey);
    }

    public List<FlightResultDto> GetFlights(FlightRequestDto flightRq)
    {
        var flig = _flights.Where(w => w.FlightDate.Date == flightRq.FlightDate.Date && flightRq.Origin == w.Origin && w.Destination == flightRq.Destination).ToList();

        var hasADT = flightRq.PaxType.Any(a => a.Type == "ADT");
        var hasCHD = flightRq.PaxType.Any(a => a.Type == "CHD");

        if (!hasADT)
            flig.ForEach(f => f.PaxPrice = f.PaxPrice.Where(w => w.Type != "ADT").ToList());
        if (!hasCHD)
            flig.ForEach(f => f.PaxPrice = f.PaxPrice.Where(w => w.Type != "CHD").ToList());

        return flig;
    }
}
