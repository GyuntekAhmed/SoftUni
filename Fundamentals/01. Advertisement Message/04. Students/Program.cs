using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < countOfStudents; i++)
            {
                string[] infoOfStudents = Console.ReadLine().Split();

                var student = new Student(infoOfStudents[0], infoOfStudents[1], double.Parse(infoOfStudents[2]));
                students.Add(student);
            }

            students = students.OrderByDescending(currentStudent => currentStudent.Grade).ToList();

            students.ForEach(student => Console.WriteLine(student));
        }
    }

    class Student
    {
        public Student(string firstName, string secondName, double grade)
        {
            FirstName = firstName;
            SecondName = secondName;
            Grade = grade;
        }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public double Grade { get; set; }

        public override string ToString() => $"{FirstName} {SecondName} {Grade:f2}";
    }
}
