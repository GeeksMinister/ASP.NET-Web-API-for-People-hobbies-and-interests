public class Labb4_API_Repository : ILabb4_API_Repository<Person, Interest, Link>
{
#pragma warning disable CS8603
#pragma warning disable CS8602
    private readonly PersonDbContext _context;
    public Labb4_API_Repository(PersonDbContext personDbContext)
    {
        _context = personDbContext;
    }
    public async Task<IEnumerable<Person>> GetAllPeople()
    {
        return await _context.Persons.ToListAsync();
    }

    public async Task<Person> GetPerson(int personId)
    {
        return await _context.Persons.FirstOrDefaultAsync(p => p.Id == personId);
    }

    public async Task<bool> CheckPersonExists(int personId)
    {
        return await _context.Persons.AnyAsync(p => p.Id == personId);
    }

    public async Task<IEnumerable<Interest>> GetAllRelatedInterests(int personId)
    {
        return await (from _interests in _context.Interests
                      where _interests.PersonId == personId
                      select _interests).ToListAsync();
    }

    public async Task<IEnumerable<Link>> GetAllRelatedLinks(int personId)
    {
        return await (from _links in _context.Links
                      where _links.PersonId == personId
                      select _links).ToListAsync();
    }

    public async Task<Interest> CreateNewInterest(Interest interest)
    {
        var result = await _context.Interests.AddAsync(interest);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Link> CreateNewLink(Link link)
    {
        var result = await _context.Links.AddAsync(link);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Person> GetAllInfoByPersonId(int personId)
    {

        var person = _context.Persons.FirstOrDefault(p => p.Id == personId);
        var interest = await (from _interests in _context.Interests
                              where _interests.PersonId == personId
                              select _interests).ToListAsync();
        var links = await (from _links in _context.Links
                           where _links.PersonId == personId
                           select _links).ToListAsync();
        return person;
    }

    public async Task<IEnumerable<Person>> SearchForPerson(string search)
    {
        IQueryable<Person> query = _context.Persons;
        return await Task.Run(() => query.Where(person =>
            person.FirstName.Contains(search) ||
            person.LastName.Contains(search)));
    }

    public async Task<IEnumerable<Person>> GetPeople(Objectparameters peopleParameters)
    {
        return await _context.Persons
            .Skip((peopleParameters.PageNumber - 1) * peopleParameters.PageSize)
            .Take(peopleParameters.PageSize)
            .ToListAsync();
    }

    public async Task<PagedList<Person>> GetPeopleEnhanced(Objectparameters peopleParameters)
    {

        return await Task.Run(() => PagedList<Person>.ToPagedList(_context.Persons,
            peopleParameters.PageNumber,
            peopleParameters.PageSize));
    }
}