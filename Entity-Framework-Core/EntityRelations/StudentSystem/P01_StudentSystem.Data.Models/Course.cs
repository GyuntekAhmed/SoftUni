namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Course
{
    public Course()
    {
        StudentCourses = new HashSet<StudentCourse>();
        Resources = new HashSet<Resource>();
        Homeworks = new HashSet<Homework>();
    }

    [Key]
    public int CourseId { get; set; }

    [Required]
    [MaxLength(GlobalConstants.CourseNameMaxLength)]
    public string Name { get; set; } = null!;

    public string? Description  { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public decimal Price { get; set; }

    public ICollection<StudentCourse> StudentCourses { get; set; }

    public ICollection<Resource> Resources { get; set; }

    public ICollection<Homework> Homeworks { get; set; }
}
