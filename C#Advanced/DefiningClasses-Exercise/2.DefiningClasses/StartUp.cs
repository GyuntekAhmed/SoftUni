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
            Person person1 = new Person();

            Person person2 = new Person(31);

            Person person3 = new Person("Gyuni", 31);

            List<Person> people = new List<Person>();

            people.Add(person1);
            people.Add(person2);
            people.Add(person3);

            foreach (var p in people)
            {
                Console.WriteLine(p.Name);
                Console.WriteLine(p.Age);
            }
        }
    }
}
