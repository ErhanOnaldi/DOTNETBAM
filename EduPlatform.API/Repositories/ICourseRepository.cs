using EduPlatform.API.Entities;

namespace EduPlatform.API.Repositories;

public interface ICourseRepository : IGenericRepository<Course>
{
    // Generic repository'nin veremeyeceği özel sorgular buraya gelir
    Task<IEnumerable<Course>> GetCoursesWithCategoryAsync();
    Task<Course?> GetCourseWithCategoryAsync(int id);
}
