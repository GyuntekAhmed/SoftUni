using DefiningClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpinionPoll
{
    public class OpinionPoll
    {
        static void Main()
        {
            List<Person> oldPersons = new List<Person>();

            int countToAddPeoples = int.Parse(Console.ReadLine());

            for (int i = 0; i < countToAddPeoples; i++)
            {
                string[] command = Console.ReadLine().Split();

                string name = command[0];
                int age = int.Parse(command[1]);

                if (age > 30)
                {
                    Person person = new Person(name, age);
                    oldPersons.Add(person);
                }
            }

            foreach (var item in oldPersons.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
            
        }
    }
}
