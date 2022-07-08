using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            const double minAvarGrade = 4.50;

            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            int countOfStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfStudents; i++)
            {
                string studentName = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(studentName))
                {
                    students[studentName] = new List<double>();
                }

                students[studentName].Add(studentGrade);
            }

            foreach (var student in students)
            {
                if (student.Value.Average() >= minAvarGrade)
                {
                    Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
                }
            }
        }
    }
}
