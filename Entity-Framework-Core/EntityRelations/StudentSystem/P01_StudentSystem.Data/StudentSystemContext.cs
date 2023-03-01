namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;

    using Common;
    using Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            : base (options)
        {

        }

        public virtual DbSet<Student> Students { get; set; } = null!;

        public virtual DbSet<Homework> Homeworks { get; set; } = null!;

        public virtual DbSet<Course> Courses { get; set; } = null!;

        public virtual DbSet<StudentCourse> StudentsCourses { get; set; } = null!;

        public virtual DbSet<Resource> Resources { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });
            });
        }
    }
}