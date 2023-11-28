using System.ComponentModel.DataAnnotations.Schema;

namespace Earthquakes.DataAccess.Entity;

public class Land : BaseEntity
{
    [Column(TypeName = "nvarchar(150)")]
    public string Name { get; set; } = null!;

    [InverseProperty("Land")]
    public ICollection<Earthquake> Earthquakes { get; set; } = new List<Earthquake>();
}