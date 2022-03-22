using System.Text.Json.Serialization;

public class InterestDto
{
#pragma warning disable CS8618
    public string Title { get; set; }
    [StringLength(320)]
    public string Description { get; set; }
    public int PersonId { get; set; }
    public InterestDto() { }
}