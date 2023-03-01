namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Student
{
    public Student()
    {
        StudentCourses = new HashSet<StudentCourse>();
        Homeworks = new HashSet<Homework>();
    }

    [Key]
    public int StudentId { get; set; }

    [Required]
    [MaxLength(GlobalConstants.StudentNameMaxLength)]
    public string Name { get; set; } = null!;

    [StringLength(GlobalConstants.StudentPhoneLength)]
    public string? PhoneNumber  { get; set; }

    [Required]
    public DateTime RegisteredOn { get; set; }

    public DateTime? Birthday  { get; set; }

    public ICollection<StudentCourse> StudentCourses { get; set; }

    public ICollection<Homework> Homeworks { get; set; }
}