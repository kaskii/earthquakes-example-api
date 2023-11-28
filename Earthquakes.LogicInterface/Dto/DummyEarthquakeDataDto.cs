namespace Earthquakes.LogicInterface.Dto;

public class DummyEarthquakeDataDto
{
    public DateTime DateTime { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public int Depth { get; set; }
    public decimal Magnitude { get; set; }
    public string Land { get; set; } = null!;
    public string Country { get; set; } = null!;
}