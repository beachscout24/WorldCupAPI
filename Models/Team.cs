using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldCupAPI.Models;

public partial class Team
{
    [Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int TeamId { get; set; }

    public string? CountryName { get; set; } 

    public int? ConfederationId { get; set; }

    public virtual Confederation? Confederation { get; set; }
}
