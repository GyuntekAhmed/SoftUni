using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] tokens = command.Split();

                if (IsStudentExisting(tokens[0], tokens[1], students))
                {
                    Student student = students.Find(student => student.FirstName == tokens[0] && student.LastName == tokens[1]);

                    student.Age = int.Parse(tokens[2]);
                    student.HomeTown = tokens[3];
                }
                else
                {
                    Student student = new Student(tokens[0], tokens[1], int.Parse(tokens[2]), tokens[3]);
                    
                    students.Add(student);
                }
            }

            string filterCity = Console.ReadLine();

            //List<Student> filteredStudent = students.Where(s => s.HomeTown == filterCity).ToList();

            //foreach (Student student in filteredStudent)
            //{
            //    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            //}

            foreach (Student student in students)
            {
                if (student.HomeTown == filterCity)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }

        }

        static bool IsStudentExisting(string firstName, string lastName, List<Student> students)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.HomeTown = homeTown;
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string HomeTown { get; set; }
    }
}
