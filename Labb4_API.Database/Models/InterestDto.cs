using System.Text.Json.Serialization;

public class InterestDto
{
#pragma warning disable CS8618
    public string Title { get; set; }
    [StringLength(320)]
    public string Description { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public Person? Person { get; set; }
    public int PersonId { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public List<Link>? Links { get; set; }

    public InterestDto() { }
}