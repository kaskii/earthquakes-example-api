using Earthquakes.LogicInterface.Dto;
using Earthquakes.LogicInterface.Dto.Request;
using Earthquakes.LogicInterface.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace Earthquakes.WebApi.Controller;

[ApiController]
[Route("/api/[controller]")]
public class EarthquakeController : ControllerBase
{
    private readonly IEarthquakeService _earthquakeService;

    public EarthquakeController(IEarthquakeService earthquakeService)
    {
        _earthquakeService = earthquakeService;
    }
    
    [HttpGet("country/{countryId}")]
    public async Task<List<EarthquakeDto>> GetByCountryId(int countryId)
    {
        return await _earthquakeService.GetEarthquakesByCountry(countryId);
    }
    
    [HttpGet("land/{landId}")]
    public async Task<List<EarthquakeDto>> GetByLandId(int landId)
    {
        return await _earthquakeService.GetEarthquakesByLand(landId);
    }

    [HttpPost]
    public async Task<EarthquakeDto> AddNew([FromBody] AddEarthquakeDto addEarthquakeDto)
    {
        return await _earthquakeService.AddNewEarthquake(addEarthquakeDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _earthquakeService.DeleteEarthquake(id);

        return Ok();
    }
}