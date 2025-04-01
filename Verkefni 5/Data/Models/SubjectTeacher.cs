namespace Verkefni_5.Data.Models;

public class SubjectTeacher
{
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
    
    // Navigation properties
    public Subject? Subject { get; set; }
    public Teacher? Teacher { get; set; }
}