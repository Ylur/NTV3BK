namespace Verkefni_5.Data.Models;

public class Subject
{
    public int SubjectId { get; set; }
    public required string Title { get; set; }
    
    // Navigation properties
    public ICollection<Mark>? Marks { get; set; } = new List<Mark>();
    public ICollection<SubjectTeacher>? SubjectTeachers { get; set; } = new List<SubjectTeacher>();
}