namespace global::ORM.Data.Entities
{
    using global::System.ComponentModel.DataAnnotations;
    using global::System.ComponentModel.DataAnnotations.Schema;

    public class EmployeeProject
    {
        [global::System.ComponentModel.DataAnnotations.Key]
        [global::System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [global::System.ComponentModel.DataAnnotations.Key]
        [global::System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
