namespace EduPlatform.API.Entities;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
}