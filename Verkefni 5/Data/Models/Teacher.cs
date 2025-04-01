namespace Verkefni_5.Data.Models;

public class Teacher
{
    public int TeacherId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    
    // Navigation property
    public ICollection<SubjectTeacher>? SubjectTeachers { get; set; } = new List<SubjectTeacher>();
}