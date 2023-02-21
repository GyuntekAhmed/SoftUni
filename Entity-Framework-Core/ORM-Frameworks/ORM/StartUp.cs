namespace ORM
{
    using global::ORM.Data;
    using global::ORM.Data.Entities;

    public class StartUp
    {
        static void Main(string[] args)
        {
            global::ORM.Data.SoftUniDbContext dbContext = new global::ORM.Data.SoftUniDbContext(global::ORM.Config.ConnectionString);

            global::ORM.Data.Entities.Employee newEmployee = global::System.Linq.Enumerable.First(e => e.FirstName == "Test");
            dbContext.Employees.Remove(newEmployee);

            dbContext.SaveChanges();
        }
    }
}