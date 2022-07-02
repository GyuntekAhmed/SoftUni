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

                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                string homeTown = tokens[3];

                Student student = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    HomeTown = homeTown
                };

                students.Add(student);
            }

            string filterCity = Console.ReadLine();

            //foreach (Student student in students)
            //{
            //    if (student.HomeTown == filterCity)
            //    {
            //        Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            //    }
            //}

            List<Student> filteredStudent = students.Where(s => s.HomeTown == filterCity).ToList();

            foreach (Student student in filteredStudent)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string HomeTown { get; set; }
    }
}
