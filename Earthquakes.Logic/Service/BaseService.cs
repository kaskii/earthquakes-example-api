using AutoMapper;
using Earthquakes.DataAccess;
using Microsoft.Extensions.Logging;

namespace Earthquakes.Logic.Service;

public class BaseService
{
    protected EarthquakeContext DbContext { get; }
    
    protected ILogger<BaseService> Logger { get; }
    
    /// <summary>
    /// AutoMapper
    /// </summary>
    protected IMapper Mapper { get; }

    protected BaseService(EarthquakeContext earthquakeContext, ILogger<BaseService> logger, IMapper mapper)
    {
        DbContext = earthquakeContext;
        Logger = logger;
        Mapper = mapper;
    }
}