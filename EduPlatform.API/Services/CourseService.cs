using EduPlatform.API.Common;
using EduPlatform.API.Data.UnitOfWork;
using EduPlatform.API.Entities;
using EduPlatform.API.Repositories;

namespace EduPlatform.API.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(
        ICourseRepository courseRepository,
        ICategoryRepository categoryRepository,
        IUnitOfWork unitOfWork)
    {
        _courseRepository = courseRepository;
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Course>> CreateCourseAsync(Course course)
    {
        // Business rule validation: Category var mı?
        var category = await _categoryRepository.GetByIdAsync(course.CategoryId);
        if (category is null)
            return Result<Course>.Failure($"Category with id {course.CategoryId} not found.");

        // Business rule: Price negatif olamaz
        if (course.Price < 0)
            return Result<Course>.Failure("Price cannot be negative.");

        await _courseRepository.AddAsync(course);
        await _unitOfWork.SaveChangesAsync();

        return Result<Course>.Success(course);
    }

    public async Task<Result<IEnumerable<Course>>> GetAllCoursesAsync()
    {
        var courses = await _courseRepository.GetCoursesWithCategoryAsync();
        return Result<IEnumerable<Course>>.Success(courses);
    }
}
