using EduPlatform.API.Entities;

namespace EduPlatform.API.DTOs;

public class UpdateCourseDto
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string InstructorName { get; set; } = string.Empty;
    public Level Level { get; set; }
    public int CategoryId { get; set; }
}
