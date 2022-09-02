using System;

namespace _07._Projects_Creation
{
    class Projects_Creation
    {
        static void Main(string[] args)
        {
            string NameArchitect = Console.ReadLine();

            int Projects = int.Parse(Console.ReadLine());
            int Hours = 3 * Projects;
            Console.WriteLine($"The architect {NameArchitect} will need {Hours} hours to complete {Projects} project/s.");
        }
    }
}
