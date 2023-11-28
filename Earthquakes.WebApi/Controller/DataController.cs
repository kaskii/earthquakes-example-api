using Earthquakes.LogicInterface.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace Earthquakes.WebApi.Controller;

[ApiController]
[Route("/api/[controller]")]
public class DataController : ControllerBase
{
    private readonly IDummyDataReader _dummyDataReader;

    public DataController(IDummyDataReader dummyDataReader)
    {
        _dummyDataReader = dummyDataReader;
    }

    [HttpGet("update-database")]
    public async Task<ActionResult> UpdateDatabase()
    {
        await _dummyDataReader.UpdateDatabase();

        return Ok();
    }
}