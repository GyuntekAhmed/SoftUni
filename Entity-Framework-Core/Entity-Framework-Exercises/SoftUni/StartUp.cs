namespace SoftUni
{
    using SoftUni.Data;
    using System.Text;

    public class StartUp
    {
        static void Main()
        {
            var dbContext = new SoftUniContext();

            var output = GetEmployeesFullInformation(dbContext);

            Console.WriteLine(output);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.Department} {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
