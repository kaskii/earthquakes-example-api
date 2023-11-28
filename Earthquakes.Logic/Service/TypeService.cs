using AutoMapper;
using Earthquakes.DataAccess;
using Earthquakes.DataAccess.Entity;
using Earthquakes.LogicInterface.Dto;
using Earthquakes.LogicInterface.ServiceInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Earthquakes.Logic.Service;

public class TypeService : BaseService, ITypeService
{
    public TypeService(EarthquakeContext earthquakeContext, ILogger<BaseService> logger, IMapper mapper) : base(earthquakeContext, logger, mapper)
    {
    }

    public async Task<Dictionary<string, List<TypeDto>>> GetAll()
    {
        return new Dictionary<string, List<TypeDto>>()
        {
            { "Countries", await GetCountries() },
            { "Lands", await GetLands() }
        };
    }

    public async Task<List<TypeDto>> GetCountries()
    {
        return await GetTypeEntity<Country>();
    }

    public async Task<List<TypeDto>> GetLands()
    {
        return await GetTypeEntity<Land>();
    }
    
    private async Task<List<TypeDto>> GetTypeEntity<T>() where T : class
    {
        var dbEntities = await DbContext.Set<T>().ToListAsync();
        return Mapper.Map<List<TypeDto>>(dbEntities);
    }
}