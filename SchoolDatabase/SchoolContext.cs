
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolDatabase
{
    // Entity classes
    public class Student
    {
        public int StudentId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int GroupId { get; set; }
        
        // Navigation properties
        public required Group Group { get; set; }
        public required ICollection<Mark> Marks { get; set; }
    }

    public class Group
    {
        public int GroupId { get; set; }
        public required string Name { get; set; }
        
        // Navigation property
        public required ICollection<Student> Students { get; set; }
    }

    public class Mark
    {
        public int MarkId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }  // Changed from 'mark' to 'Value' for clarity
        
        // Navigation properties
        public required Student Student { get; set; }
        public required Subject Subject { get; set; }
    }

    public class Subject
    {
        public int SubjectId { get; set; }
        public required string Title { get; set; }
        
        // Navigation properties
        public required ICollection<Mark> Marks { get; set; }
        public required ICollection<Teacher> Teachers { get; set; }
    }

    public class Teacher
    {
        public int TeacherId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        
        // Navigation property
        public required List<Subject> Subjects { get; set; }
    }

   /* public class SubjectTeacher
    {
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        
        // Navigation properties
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
    }*/


    // DbContext class
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<SubjectTeacher> SubjectTeachers { get; set; }

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

           // modelBuilder.Entity<Subject>()
             //   .HasKey(st => new { st.SubjectId, st.TeacherId });

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

           /* // SubjectTeacher - Subject (Many-to-One)
            modelBuilder.Entity<SubjectTeacher>()
                .HasOne(st => st.Subject)
                .WithMany(s => s.SubjectTeachers)
                .HasForeignKey(st => st.SubjectId);

            // SubjectTeacher - Teacher (Many-to-One)
            modelBuilder.Entity<SubjectTeacher>()
                .HasOne(st => st.Teacher)
                .WithMany(t => t.SubjectTeachers)
                .HasForeignKey(st => st.TeacherId);
                */
        } 
    } 
}