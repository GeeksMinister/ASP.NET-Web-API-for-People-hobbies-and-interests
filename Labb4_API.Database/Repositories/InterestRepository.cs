public class InterestRepository : IDatabaseRepository<Interest>
{
#pragma warning disable CS8603
    private readonly PersonDbContext _context;
    public InterestRepository(PersonDbContext context)
    {
        _context = context;
    }

    public async Task<Interest> AddEntity(Interest newEntity)
    {
        var result = await _context.Interests.AddAsync(newEntity);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public int CountEntities()
    {
        return (from id in _context.Interests select id).Count();
    }
}
