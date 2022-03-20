public class PersonRepository : IDatabaseRepository<Person>
{
#pragma warning disable CS8603
    private readonly PersonDbContext _context;
    public PersonRepository(PersonDbContext context)
    {
        _context = context;
    }

    public async Task<Person> AddEntity(Person newEntity)
    {
        var result = await _context.Persons.AddAsync(newEntity);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public int CountEntities()
    {
        return (from id in _context.Persons select id).Count();
    }

}