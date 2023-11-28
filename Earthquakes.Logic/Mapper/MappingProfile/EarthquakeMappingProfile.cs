using AutoMapper;
using Earthquakes.DataAccess.Entity;
using Earthquakes.LogicInterface.Dto;
using Earthquakes.LogicInterface.Dto.Request;

namespace Earthquakes.Logic.Mapper.MappingProfile;

public class EarthquakeMappingProfile : Profile
{
    public EarthquakeMappingProfile()
    {
        CreateMap<Earthquake, EarthquakeDto>()
            .ReverseMap()
            .ForMember(dst => dst.Country, opt => opt.Ignore())
            .ForMember(dst => dst.Land, opt => opt.Ignore());

        CreateMap<AddEarthquakeDto, Earthquake>()
            .ForMember(dst => dst.Id, opt => opt.Ignore());
    }
}