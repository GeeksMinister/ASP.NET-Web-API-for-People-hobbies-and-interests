public interface IDatabaseRepository<T>
{
    Task<T> AddEntity(T newEntity);
    int CountEntities();
}