using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTOs 
{
    // Base DTO classes
    public class StudentDto
    {
        public int StudentId { get; set; }        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }    }

    public class StudentCreateDto
    {        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        
        [Required]
        public int GroupId { get; set; }    }

    public class StudentUpdateDto
    {        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        
        [Required]
        public int GroupId { get; set; }    }

    public class GroupDto
    {
        public int GroupId { get; set; }        public string Name { get; set; }
        public int StudentCount { get; set; }    }

    public class GroupCreateDto
    {        [Required]
        [StringLength(50)]
        public string Name { get; set; }    }

    public class GroupUpdateDto
    {        [Required]
        [StringLength(50)]
        public string Name { get; set; }    }

    public class MarkDto
    {
        public int MarkId { get; set; }        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectTitle { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }    }

    public class MarkCreateDto
    {        [Required]
        public int StudentId { get; set; }
        
        [Required]
        public int SubjectId { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        [Range(0, 100)]
        public int Value { get; set; }    }

    public class MarkUpdateDto
    {        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        [Range(0, 100)]
        public int Value { get; set; }    }

    public class SubjectDto
    {
        public int SubjectId { get; set; }        public string Title { get; set; }    }

    public class SubjectCreateDto
    {        [Required]
        [StringLength(100)]
        public string Title { get; set; }    }

    public class SubjectUpdateDto
    {        [Required]
        [StringLength(100)]
        public string Title { get; set; }    }

    public class TeacherDto
    {
        public int TeacherId { get; set; }        public string FirstName { get; set; }
        public string LastName { get; set; }    }

    public class TeacherCreateDto
    {        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }    }

    public class TeacherUpdateDto
    {        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }    }

    public class SubjectTeacherDto
    {
        public int SubjectTeacherId { get; set; }        public int SubjectId { get; set; }
        public string SubjectTitle { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }    }

    public class SubjectTeacherCreateDto
    {        [Required]
        public int SubjectId { get; set; }
        
        [Required]
        public int TeacherId { get; set; }    }

    public class SubjectTeacherUpdateDto
    {        // SubjectTeacher doesn't have an update DTO as it's a join table
        // To update, delete the relationship and create a new one    }
}
