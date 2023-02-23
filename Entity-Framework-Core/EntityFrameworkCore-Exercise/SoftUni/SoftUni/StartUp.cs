using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();

            string output = GetEmployeesFullInformation(dbContext);

            Console.WriteLine(output);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Employee[] employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .ToArray();

            foreach (Employee ep in employees)
            {
                sb.AppendLine($"{ep.FirstName} {ep.LastName} {ep.MiddleName} {ep.JobTitle} {ep.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}