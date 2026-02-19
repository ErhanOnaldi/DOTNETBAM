using EduPlatform.API.Entities;

namespace EduPlatform.API.Repositories;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<Category?> GetCategoryWithCoursesAsync(int id);
}
