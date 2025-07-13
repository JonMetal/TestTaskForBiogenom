using System.Text.Json.Serialization;

namespace TestTaskForBioGenom.Database.Entities;

public partial class Vitamine
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public decimal? DailyIntake { get; set; }

    public string? Unit { get; set; }

    [JsonIgnore]
    public virtual ICollection<DietarySupplementsVitamine> DietarySupplementsVitamines { get; set; } = new List<DietarySupplementsVitamine>();

    [JsonIgnore]
    public virtual ICollection<VitaminesForm> VitaminesForms { get; set; } = new List<VitaminesForm>();
}
