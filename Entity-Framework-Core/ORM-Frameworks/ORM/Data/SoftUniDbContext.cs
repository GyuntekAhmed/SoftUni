using global::MiniORM;

namespace global::ORM.Data
{
    using Entities;
    using global::System.Collections.Generic;

    public class SoftUniDbContext : global::MiniORM.DbContext
    {
        public SoftUniDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public global::MiniORM.DbSet<Employee> Employees { get; set; }

        public global::MiniORM.DbSet<Project> Projects { get; set; }

        public global::MiniORM.DbSet<Department> Departments { get; set; }

        public global::MiniORM.DbSet<EmployeeProject> EmployeesProjects { get; set; }
    }
}
