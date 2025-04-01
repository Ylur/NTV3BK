
namespace Verkefni_5.Data.Models;

public class Mark
{
    public int MarkId { get; set; }
    public int StudentId { get; set; }
    public int SubjectId { get; set; }
    public DateTime Date { get; set; }
        public int Value { get; set; }  // Changed from 'mark' to 'Value' for clarity
        
        // Navigation properties
    public Student? Student { get; set; }
    public Subject? Subject { get; set; }
    }