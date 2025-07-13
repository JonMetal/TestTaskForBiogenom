using System.Text.Json.Serialization;

namespace TestTaskForBioGenom.Database.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Login { get; set; }

    [JsonIgnore]
    public string? Password { get; set; }

    [JsonIgnore]
    public virtual ICollection<Form> Forms { get; set; } = new List<Form>();
}
