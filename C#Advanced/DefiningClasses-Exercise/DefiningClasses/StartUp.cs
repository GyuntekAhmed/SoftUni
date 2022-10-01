using DefiningClasses;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            Family family = new Family();

            int countOfPeoples = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfPeoples; i++)
            {
                string[] command = Console.ReadLine().Split();

                string name = command[0];
                int age = int.Parse(command[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
            }

            Person oldestPerson = family.GetOldestMember();


            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
