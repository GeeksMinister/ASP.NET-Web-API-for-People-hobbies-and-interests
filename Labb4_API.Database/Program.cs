using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    private readonly Database database;

    static void Main(string[] args)
    {
        var host = CreatehostBuilder(args).Build();
        host.Services.GetRequiredService<Program>().Run();
    }

    public Program( Database database) => this.database = database;

    static IHostBuilder CreatehostBuilder(string[] args)
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddDbContextPool<PersonDbContext>(options =>
                {
                    options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
                });
                services.AddTransient<Program>();
                services.AddTransient<Database>();
                services.AddTransient<PersonDbContext>();
                services.AddScoped<IDatabaseRepository<Person>, PersonRepository>();
                services.AddScoped<IDatabaseRepository<Interest>, InterestRepository>();
                services.AddScoped<IDatabaseRepository<Link>, LinkRepository>();
            });
    }
    void Run() => database.PrintMenu();
}


