using System.Text.Json.Serialization;

namespace TestTaskForBioGenom.Database.Entities;

public partial class DietarySupplementsVitamine
{
    public int DietarySupplementId { get; set; }

    public int VitamineId { get; set; }

    public decimal? VolumePerTablet { get; set; }

    [JsonIgnore]
    public virtual DietarySupplement DietarySupplement { get; set; } = null!;

    [JsonIgnore]
    public virtual Vitamine Vitamine { get; set; } = null!;
}
