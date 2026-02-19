using EduPlatform.API.Data;
using EduPlatform.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduPlatform.API.Repositories;

public class CourseRepository : GenericRepository<Course>, ICourseRepository
{
    public CourseRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Course>> GetCoursesWithCategoryAsync()
    {
        // Generic GetAllAsync Include yapamaz — tipi bilmiyor
        // Bu yüzden özel sorgu buraya geliyor
        return await _context.Courses
            .Include(c => c.Category)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Course?> GetCourseWithCategoryAsync(int id)
    {
        // FindAsync Include'u desteklemiyor → FirstOrDefaultAsync kullanıyoruz
        return await _context.Courses
            .Include(c => c.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}
