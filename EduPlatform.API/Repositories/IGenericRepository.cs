namespace EduPlatform.API.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);   // async değil — sadece Change Tracker'a işaret koyar
    void Delete(T entity);   // async değil — sadece Change Tracker'a işaret koyar
}
