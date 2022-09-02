using System;

namespace _06._Concatenate_Data
{
    class _Concatenate_Data
    {
        static void Main(string[] args)
        {
            string FirstName = Console.ReadLine();

            string LastName = Console.ReadLine();
            int Age = int.Parse(Console.ReadLine());
            string Town = Console.ReadLine();
            Console.WriteLine($"You are {FirstName} {LastName}, a {Age}-years old person from {Town}."); ;
        }
    }
}
