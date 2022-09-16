using System;
using System.Collections.Generic;
using System.Linq;

class Average_Student_Grades
{
    static void Main()
    {
        Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

        int countOfStudents = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfStudents; i++)
        {
            string[] infoAboutStudent = Console.ReadLine().Split(' ');
            string name = infoAboutStudent[0];
            decimal grade = decimal.Parse(infoAboutStudent[1]);

            if (students.ContainsKey(name) == false)
            {
                students.Add(name, new List<decimal>());
            }

            students[name].Add(grade);
        }

        foreach (var student in students)
        {
            Console.Write($"{student.Key} -> ");

            foreach (decimal grade in student.Value)
            {
                Console.Write($"{grade:f2} ");
            }

            Console.Write($"(avg: {student.Value.Average():f2})");
            Console.WriteLine();
        }
    }
}
