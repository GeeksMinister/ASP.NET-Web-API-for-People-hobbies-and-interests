public class Person
{
#pragma warning disable CS8618
    [Key]
    public int Id { get; set; } = 0;
    public string Name { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int Balance { get; set; } = 0;
    [StringLength(10)]
    public string? Phone { get; set; }
    public string City { get; set; }
    public string? Email { get; set; }
    public List<Interest> Interests { get; set; }
    public List<Link> Links { get; set; }

}