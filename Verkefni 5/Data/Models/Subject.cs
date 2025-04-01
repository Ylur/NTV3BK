namespace Verkefni_5.Data.Models;

public class Subject
{
    public int SubjectId { get; set; }
    public required string Title { get; set; }
    
    // Navigation properties
    public ICollection<Mark>? Marks { get; set; } = new List<Mark>();
    public List<Teacher>? Teachers { get; set; } = new List<Teacher>();
}