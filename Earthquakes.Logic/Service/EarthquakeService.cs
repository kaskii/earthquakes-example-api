using AutoMapper;
using Earthquakes.DataAccess;
using Earthquakes.DataAccess.Entity;
using Earthquakes.LogicInterface.Dto;
using Earthquakes.LogicInterface.Dto.Request;
using Earthquakes.LogicInterface.ServiceInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Earthquakes.Logic.Service;

public class EarthquakeService : BaseService, IEarthquakeService
{
    public EarthquakeService(EarthquakeContext earthquakeContext, ILogger<BaseService> logger, IMapper mapper) : base(earthquakeContext, logger, mapper)
    {
    }

    public async Task<List<EarthquakeDto>> GetEarthquakesByCountry(int countryId)
    {
        // Return empty list if country does not exist
        if (await DbContext.Countries.CountAsync(c => c.Id == countryId) == 0)
            return new List<EarthquakeDto>();

        var dbEarthquakes = await DbContext.Earthquakes
            .Where(e => e.CountryId == countryId)
            .ToListAsync();

        return Mapper.Map<List<EarthquakeDto>>(dbEarthquakes);
    }

    public async Task<List<EarthquakeDto>> GetEarthquakesByLand(int landId)
    {
        // Return empty list if land does not exist
        if (await DbContext.Lands.CountAsync(l => l.Id == landId) == 0)
            return new List<EarthquakeDto>();

        var dbEarthquakes = await DbContext.Earthquakes
            .Where(e => e.LandId == landId)
            .ToListAsync();

        return Mapper.Map<List<EarthquakeDto>>(dbEarthquakes);
    }

    public async Task<EarthquakeDto> AddNewEarthquake(AddEarthquakeDto addEarthquakeDto)
    {
        var newEarthquake = Mapper.Map<Earthquake>(addEarthquakeDto);
        
        DbContext.Earthquakes.Add(newEarthquake);
        await DbContext.SaveChangesAsync();

        var dbEarthquake = await DbContext.Earthquakes
            .SingleAsync(e => e.Id == newEarthquake.Id);

        return Mapper.Map<EarthquakeDto>(dbEarthquake);
    }

    public async Task DeleteEarthquake(int id)
    {
        var dbEarthquake = await DbContext.Earthquakes
            .SingleOrDefaultAsync(e => e.Id == id);

        if (dbEarthquake is null)
        {
            Logger.LogWarning("Tried to delete non-existing data by id {Id}", id);
            return;
        }

        DbContext.Earthquakes.Remove(dbEarthquake);
        await DbContext.SaveChangesAsync();
    }
}