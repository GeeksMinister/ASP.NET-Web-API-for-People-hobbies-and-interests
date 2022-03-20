public partial class PersonDbContext : DbContext
{
#pragma warning disable CS8618
    public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }

    public virtual DbSet<Person> Persons { get; set; }
    public virtual DbSet<Interest> Interests { get; set; }
    public virtual DbSet<Link> Links { get; set; }

}