using System.ComponentModel.DataAnnotations.Schema;

namespace Earthquakes.DataAccess.Entity;

public class Country : BaseEntity
{
    [Column(TypeName = "nvarchar(150)")]
    public string Name { get; set; } = null!;
    
    [InverseProperty("Country")]
    public ICollection<Earthquake> Earthquakes { get; set; } = new List<Earthquake>();
}