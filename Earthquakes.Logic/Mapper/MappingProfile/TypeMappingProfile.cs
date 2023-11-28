using AutoMapper;
using Earthquakes.DataAccess.Entity;
using Earthquakes.LogicInterface.Dto;

namespace Earthquakes.Logic.Mapper.MappingProfile;

public class TypeMappingProfile : Profile
{
    public TypeMappingProfile()
    {
        CreateMap<Country, TypeDto>();
        CreateMap<Land, TypeDto>();
    }
}