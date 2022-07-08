using System;
using System.Collections.Generic;

namespace _05._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courseInfo = new Dictionary<string, List<string>>();

            while (true)
            {
                string comand = Console.ReadLine();
                if (comand == "end")
                {
                    break;
                }

                string[] tokens = comand.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string courseName = tokens[0];
                string studentName = tokens[1];

                if (!courseInfo.ContainsKey(courseName))
                {
                    courseInfo[courseName] = new List<string>();
                }
                courseInfo[courseName].Add(studentName);
            }

            foreach (var item in courseInfo)
            {
                string courseName = item.Key;
                var students = item.Value;
                Console.WriteLine($"{courseName}: {students.Count}");
                foreach (var student in students)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
