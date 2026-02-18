namespace EduPlatform.API.Entities;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public bool IsDeleted { get; set; }
    public string InstructorName { get; set; } = null!;
    public Level Level  { get; set; }

    // İlişki — FK
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;  // Navigation property
}

public enum Level
{
    Beginner,
    Intermediate,
    Advanced,
}
