using System.ComponentModel.DataAnnotations.Schema;

namespace Earthquakes.DataAccess.Entity;

public class Earthquake : BaseEntity
{
    public int LandId { get; set; }
    public int CountryId { get; set; }
    
    public DateTime DateTime { get; set; }
    
    [Column(TypeName = "decimal(6,3)")]
    public decimal Latitude { get; set; }
    
    [Column(TypeName = "decimal(6,3)")]
    public decimal Longitude { get; set; }
    
    public int Depth { get; set; }
    
    [Column(TypeName = "decimal(2,1)")]
    public decimal Magnitude { get; set; }

    [ForeignKey(nameof(LandId))]
    [InverseProperty("Earthquakes")]
    public Land Land { get; set; } = null!;

    [ForeignKey(nameof(CountryId))]
    [InverseProperty("Earthquakes")]
    public Country Country { get; set; } = null!;
}