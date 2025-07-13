using System.Text.Json.Serialization;

namespace TestTaskForBioGenom.Database.Entities;

public partial class DietarySupplement
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public decimal? DailyIntake { get; set; }

    public int? TabletsCount { get; set; }

    public decimal? Price { get; set; }

    [JsonIgnore]
    public virtual ICollection<DietarySupplementsVitamine> DietarySupplementsVitamines { get; set; } = new List<DietarySupplementsVitamine>();
}
