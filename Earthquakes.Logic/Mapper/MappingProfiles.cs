using AutoMapper;
using Earthquakes.Logic.Mapper.MappingProfile;

namespace Earthquakes.Logic.Mapper;

public static class MappingProfiles
{
    public static MapperConfiguration GetMappings()
    {
        return new MapperConfiguration(mc =>
        {
            mc.AddProfile(new TypeMappingProfile());
            mc.AddProfile(new EarthquakeMappingProfile());
        });
    }
}