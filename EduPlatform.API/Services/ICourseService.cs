using EduPlatform.API.Common;
using EduPlatform.API.Entities;

namespace EduPlatform.API.Services;

public interface ICourseService
{
    Task<Result<Course>> CreateCourseAsync(Course course);
    Task<Result<IEnumerable<Course>>> GetAllCoursesAsync();
}
