using System.Text.Json.Serialization;

namespace TestTaskForBioGenom.Database.Entities;

public partial class VitaminesForm
{
    public int VitamineId { get; set; }

    public int FormId { get; set; }

    public decimal? Intake { get; set; }

    [JsonIgnore]
    public virtual Form Form { get; set; } = null!;

    [JsonIgnore]
    public virtual Vitamine Vitamine { get; set; } = null!;
}
