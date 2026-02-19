namespace EduPlatform.API.Data.UnitOfWork;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
}
