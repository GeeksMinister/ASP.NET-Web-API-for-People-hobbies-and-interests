using System.Text.Json.Serialization;

public class Person
{
#pragma warning disable CS8618
    [Key]
    public int Id { get; set; } = 0;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    [StringLength(50)]
    public string? Phone { get; set; }
    public string City { get; set; }
    public string? Email { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public List<Interest> Interests { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public List<Link> Links { get; set; }

    public Person() { }
}