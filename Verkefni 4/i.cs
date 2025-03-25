using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolDB
{
    // Entity classes
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
        
        // Navigation properties
        public Group Group { get; set; }
        public ICollection<Mark> Marks { get; set; }
    }

    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        
        // Navigation property
        public ICollection<Student> Students { get; set; }
    }

    public class Mark
    {
        public int MarkId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }  
        
        // Navigation properties
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }

    public class Subject
    {
        public int SubjectId { get; set; }
        public string Title { get; set; }
        
        // Navigation properties
        public ICollection<Mark> Marks { get; set; }
        public ICollection<SubjectTeacher> SubjectTeachers { get; set; }
    }

    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        // Navigation property
        public ICollection<SubjectTeacher> SubjectTeachers { get; set; }
    }

    public class SubjectTeacher
    {
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        
        // Navigation properties
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
    }

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