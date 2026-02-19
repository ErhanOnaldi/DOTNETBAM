namespace EduPlatform.API.Data.UnitOfWork;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
