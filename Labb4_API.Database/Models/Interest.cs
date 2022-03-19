public class Interest
{
#pragma warning disable CS8618
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    [StringLength(320)]
    public string Description { get; set; }
    public Person Person { get; set; }
    public int PersonId { get; set; }
    public List<Link> Links { get; set; }
}