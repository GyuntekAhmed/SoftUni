using System;
using System.Collections.Generic;
using System.Linq;

class Average_Student_Grades
{
    static void Main()
    {
        Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

        int countOfStudents = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfStudents; i++)
        {
            string[] infoAboutStudent = Console.ReadLine().Split(' ');
            string name = infoAboutStudent[0];
            double grade = double.Parse(infoAboutStudent[1]);
            
            students.Add(name, new List<double>());
            students["name"].Add(grade);
        }

        foreach (var student in students)
        {
            Console.WriteLine($"{student.Key} -> {string.Join(' ', student.Value)} (avg: {student.Value.Average():f2})");
        }
    }
}
