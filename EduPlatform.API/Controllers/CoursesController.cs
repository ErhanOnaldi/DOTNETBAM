using EduPlatform.API.Data.UnitOfWork;
using EduPlatform.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EduPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController(ICourseRepository courseRepository, IUnitOfWork unitOfWork) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var courses = await courseRepository.GetCoursesWithCategoryAsync();
        return Ok(courses);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var course = await courseRepository.GetCourseWithCategoryAsync(id);

        if (course is null)
            return NotFound(new { message = $"Course with id {id} not found." });

        return Ok(course);
    }
}
