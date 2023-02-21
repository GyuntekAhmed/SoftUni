namespace global::ORM.Data.Entities
{
    using global::System.ComponentModel.DataAnnotations;

    public class Department
    {
        [global::System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        [global::System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public global::System.Collections.Generic.ICollection<Employee> Employees { get; set; }
    }
}
