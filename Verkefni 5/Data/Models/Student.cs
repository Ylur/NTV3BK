namespace Verkefni_5.Data.Models;
public class Student
{
    public int StudentId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public int GroupId { get; set; }
    
    // Navigation properties
    public Group? Group { get; set; }
    public ICollection<Mark>? Marks { get; set; } = new List<Mark>();
}