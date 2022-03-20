public interface ILabb4_API_Repository
{
    Task<IEnumerable< Person>> GetAllPeople();
    Task<Person> GetPerson(int personId);
    Task<bool> CheckPersonExists(int personId);
    Task<IEnumerable<Interest>> GetAllRelatedInterests(int personId);
    Task<IEnumerable<Link>> GetAllRelatedLinks(int personId);
    Task<Interest> CreateNewInterest(Interest interestDto);
    Task<Link> CreateNewLink(Link linkDto);

}