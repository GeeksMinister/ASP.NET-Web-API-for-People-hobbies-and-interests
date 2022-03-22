using System.Text.Json.Serialization;

public class LinkDto
{
#pragma warning disable CS8618
    public string Url { get; set; }
    public int? PersonId { get; set; }
    public int InterestId { get; set; }

    public LinkDto() { }
}