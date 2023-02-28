namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Student
{
    [Key]
    public int StudentId { get; set; }

    [Required]
    [MaxLength(GlobalConstants.StudentNameMaxLength)]
    public string Name { get; set; } = null!;
}