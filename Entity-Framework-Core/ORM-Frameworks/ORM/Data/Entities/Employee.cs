namespace global::ORM.Data.Entities
{
    using global::System.ComponentModel.DataAnnotations;
    using global::System.ComponentModel.DataAnnotations.Schema;

    public class Employee
    {
        [global::System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        [global::System.ComponentModel.DataAnnotations.Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [global::System.ComponentModel.DataAnnotations.Required]
        public string LastName { get; set; }

        public bool IsEmployed { get; set; }

        [global::System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public global::System.Collections.Generic.ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
