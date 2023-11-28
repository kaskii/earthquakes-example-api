using Earthquakes.LogicInterface.Dto;
using Earthquakes.LogicInterface.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace Earthquakes.WebApi.Controller;

[ApiController]
[Route("/api/[controller]")]
public class TypeController : ControllerBase
{
    private readonly ITypeService _typeService;

    public TypeController(ITypeService typeService)
    {
        _typeService = typeService;
    }

    [HttpGet("all")]
    public async Task<Dictionary<string, List<TypeDto>>> GetAllTypes()
    {
        return await _typeService.GetAll();
    }
    
    [HttpGet("countries")]
    public async Task<List<TypeDto>> GetCountries()
    {
        return await _typeService.GetCountries();
    }
    
    [HttpGet("lands")]
    public async Task<List<TypeDto>> GetLands()
    {
        return await _typeService.GetLands();
    }
}