using Microsoft.Extensions.Configuration;

public class PersonDbContext : DbContext
{
#pragma warning disable CS8618
    public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }
    public PersonDbContext() { }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Interest> Interests { get; set; }
    public DbSet<Link> Links { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //if (!optionsBuilder.IsConfigured)
        //{
        //    optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB; Database=Labb4_API;" +
        //        " Trusted_Connection=True; MultipleActiveResultSets=True");
        //}
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
    }
}