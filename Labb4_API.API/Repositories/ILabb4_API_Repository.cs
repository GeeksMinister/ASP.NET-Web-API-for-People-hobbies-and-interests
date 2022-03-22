public interface ILabb4_API_Repository<T, U, V>
{
    Task<IEnumerable<T>> GetAllPeople();
    Task<T> GetPerson(int personId);
    Task<bool> CheckPersonExists(int personId);
    Task<IEnumerable<U>> GetAllRelatedInterests(int personId);
    Task<IEnumerable<V>> GetAllRelatedLinks(int personId);
    Task<U> CreateNewInterest(U interestDto);
    Task<V> CreateNewLink(V linkDto);
    Task<T> GetAllInfoByPersonId(int personId);
    Task<IEnumerable<T>> SearchForPerson(string search);
    Task<IEnumerable<T>> GetPeople(Objectparameters ownerParameters);
    Task<PagedList<T>> GetPeopleEnhanced(Objectparameters ownerParameters);
}