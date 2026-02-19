using EduPlatform.API.Data;
using EduPlatform.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduPlatform.API.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context) { }

    public async Task<Category?> GetCategoryWithCoursesAsync(int id)
    {
        return await _context.Categories
            .Include(c => c.Courses)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}
