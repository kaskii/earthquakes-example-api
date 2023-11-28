namespace Earthquakes.LogicInterface.Dto;

public class EarthquakeDto
{
    public int Id { get; set; }
    public int LandId { get; set; }
    public int CountryId { get; set; }
    public DateTime DateTime { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public int Depth { get; set; }
    public decimal Magnitude { get; set; }
}