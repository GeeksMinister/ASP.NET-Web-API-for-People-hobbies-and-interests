using System.Text.Json.Serialization;

public class Link
{
#pragma warning disable CS8618
    [Key]
    public int Id { get; set; }
    public string Url { get; set; }
    public int? PersonId { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Person? Person { get; set; }
    public int InterestId { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Interest? Interest { get; set; }

    public Link() { }
}