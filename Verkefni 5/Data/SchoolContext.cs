using Microsoft.EntityFrameworkCore;
using Verkefni_5.Data.Models;

namespace Verkefni_5.Data
{
    // DbContext class
    public class SchoolContext : DbContext
    {   
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<SubjectTeacher> SubjectTeachers { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary keys
            modelBuilder.Entity<Student>()
                .HasKey(s => s.StudentId);

            modelBuilder.Entity<Group>()
                .HasKey(g => g.GroupId);

            modelBuilder.Entity<Mark>()
                .HasKey(m => m.MarkId);

            modelBuilder.Entity<Subject>()
                .HasKey(s => s.SubjectId);

            modelBuilder.Entity<Teacher>()
                .HasKey(t => t.TeacherId);

            modelBuilder.Entity<SubjectTeacher>()
                .HasKey(st => new { st.SubjectId, st.TeacherId });

            // Configure relationships
            // Student - Group (Many-to-One)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GroupId);

            // Mark - Student (Many-to-One)
            modelBuilder.Entity<Mark>()
                .HasOne(m => m.Student)
                .WithMany(s => s.Marks)
                .HasForeignKey(m => m.StudentId);

            // Mark - Subject (Many-to-One)
            modelBuilder.Entity<Mark>()
                .HasOne(m => m.Subject)
                .WithMany(s => s.Marks)
                .HasForeignKey(m => m.SubjectId);

            // SubjectTeacher - Subject (Many-to-One)
            modelBuilder.Entity<SubjectTeacher>()
                .HasOne(st => st.Subject)
                .WithMany(s => s.SubjectTeachers)
                .HasForeignKey(st => st.SubjectId);

            // SubjectTeacher - Teacher (Many-to-One)
            modelBuilder.Entity<SubjectTeacher>()
                .HasOne(st => st.Teacher)
                .WithMany(t => t.SubjectTeachers)
                .HasForeignKey(st => st.TeacherId);
        } 
    }
}