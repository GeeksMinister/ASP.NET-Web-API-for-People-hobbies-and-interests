public interface ILabb4_API_Repository
{
    Task<IEnumerable< Person>> GetAllPeople();
    Task<IEnumerable<Interest>> GetAllRelatedInterests(int personId);
    Task<IEnumerable<Link>> GetAllRelatedLinks(int personId);
    Task<Interest> CreateNewInterest(Interest interest);
    Task<Link> CreateNewLink(Link link);

}