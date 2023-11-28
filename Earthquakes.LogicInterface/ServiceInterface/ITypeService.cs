using Earthquakes.LogicInterface.Dto;

namespace Earthquakes.LogicInterface.ServiceInterface;

public interface ITypeService
{
    Task<Dictionary<string, List<TypeDto>>> GetAll();
    Task<List<TypeDto>> GetCountries();
    Task<List<TypeDto>> GetLands();
    
    
}