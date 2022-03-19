public class LinkRepository : IDatabaseRepository<Link>
{
    private readonly PersonDbContext _context;
    public LinkRepository(PersonDbContext context)
    {
        _context = context;
    }
    public async Task<Link> AddEntity(Link newEntity)
    {
        var result = await _context.Links.AddAsync(newEntity);
        await _context.SaveChangesAsync();
        return result.Entity;
    }
}