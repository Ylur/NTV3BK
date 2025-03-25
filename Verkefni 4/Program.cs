
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SchoolDB;Trusted_Connection=True;");
            
            using (var context = new SchoolContext(optionsBuilder.Options))
            {
                // database is created
                context.Database.EnsureCreated();
                
                // seeding some data
                if (!context.Groups.Any())
                {
                    SeedData(context);
                }
                
                // query
                var studentsInGroup = context.Students
                    .Include(s => s.Group)
                    .Include(s => s.Marks)
                        .ThenInclude(m => m.Subject)
                    .Where(s => s.Group.Name == "Class 1A")
                    .ToList();
                
                
            }
        }
        
        private static void SeedData(SchoolContext context)
        {
            // Add groups
            var group1A = new Group { Name = "Class 1A" };
            var group1B = new Group { Name = "Class 1B" };
            context.Groups.AddRange(group1A, group1B);
            
            // Add subjects
            var mathSubject = new Subject { Title = "Mathematics" };
            var scienceSubject = new Subject { Title = "Science" };
            context.Subjects.AddRange(mathSubject, scienceSubject);
            
            // Add teachers
            var teacher1 = new Teacher { FirstName = "John", LastName = "Doe" };
            var teacher2 = new Teacher { FirstName = "Jane", LastName = "Smith" };
            context.Teachers.AddRange(teacher1, teacher2);
            
            // Save to generate IDs
            context.SaveChanges();
            
            // Add teacher-subject relationships
            var mathTeacher = new SubjectTeacher { SubjectId = mathSubject.SubjectId, TeacherId = teacher1.TeacherId };
            var scienceTeacher = new SubjectTeacher { SubjectId = scienceSubject.SubjectId, TeacherId = teacher2.TeacherId };
            context.SubjectTeachers.AddRange(mathTeacher, scienceTeacher);
            
            // Add students
            var student1 = new Student { FirstName = "Alice", LastName = "Johnson", GroupId = group1A.GroupId };
            var student2 = new Student { FirstName = "Bob", LastName = "Williams", GroupId = group1A.GroupId };
            var student3 = new Student { FirstName = "Charlie", LastName = "Brown", GroupId = group1B.GroupId };
            context.Students.AddRange(student1, student2, student3);
            
            // Save to generate IDs
            context.SaveChanges();
            
            // Add some marks
            var mark1 = new Mark { StudentId = student1.StudentId, SubjectId = mathSubject.SubjectId, Date = DateTime.Now, Value = 85 };
            var mark2 = new Mark { StudentId = student1.StudentId, SubjectId = scienceSubject.SubjectId, Date = DateTime.Now, Value = 90 };
            var mark3 = new Mark { StudentId = student2.StudentId, SubjectId = mathSubject.SubjectId, Date = DateTime.Now, Value = 78 };
            context.Marks.AddRange(mark1, mark2, mark3);
            
            context.SaveChanges();
        }
    }