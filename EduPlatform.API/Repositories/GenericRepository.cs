using EduPlatform.API.Data;
using Microsoft.EntityFrameworkCore;

namespace EduPlatform.API.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        // FindAsync → önce Change Tracker'a bakar, yoksa DB'ye gider
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        // AsNoTracking → sadece okuma, Change Tracker'a eklemez → daha hızlı
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        // Not: SaveChanges YOK — bu UoW'un sorumluluğu
    }

    public void Update(T entity)
    {
        // Sadece Change Tracker'a "Modified" işareti koyar, DB'ye yazmaz
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        // Sadece Change Tracker'a "Deleted" işareti koyar, DB'ye yazmaz
        _dbSet.Remove(entity);
    }
}
