using Earthquakes.LogicInterface.Dto;
using Earthquakes.LogicInterface.Dto.Request;

namespace Earthquakes.LogicInterface.ServiceInterface;

public interface IEarthquakeService
{
    Task<List<EarthquakeDto>> GetEarthquakesByCountry(int countryId);
    Task<List<EarthquakeDto>> GetEarthquakesByLand(int landId);

    Task<EarthquakeDto> AddNewEarthquake(AddEarthquakeDto addEarthquakeDto);
    Task DeleteEarthquake(int id);
}