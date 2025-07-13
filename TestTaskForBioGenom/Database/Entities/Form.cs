using System.Text.Json.Serialization;

namespace TestTaskForBioGenom.Database.Entities;

public partial class Form
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreateDate { get; set; }

    [JsonIgnore]
    public virtual User? User { get; set; }

    [JsonIgnore]
    public virtual ICollection<VitaminesForm> VitaminesForms { get; set; } = new List<VitaminesForm>();
}
