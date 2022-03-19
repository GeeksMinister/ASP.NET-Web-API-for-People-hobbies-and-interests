public partial class PersonDbContext : DbContext
{
#pragma warning disable CS8618
    public PersonDbContext()
    {
    }

    public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }

    public virtual DbSet<Person> Persons { get; set; }
    public virtual DbSet<Interest> Interests { get; set; }
    public virtual DbSet<Link> Links { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
    }
}