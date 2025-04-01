namespace Verkefni_5.Data.Models;

public class Group
{
    public int GroupId { get; set; }
    public required string Name { get; set; }
    
    // Navigation property
    public ICollection<Student>? Students { get; set; } = new List<Student>();
}