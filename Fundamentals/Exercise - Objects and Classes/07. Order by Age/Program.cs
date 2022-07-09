using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] comands = Console.ReadLine().Split();
            List<Person> personList = new List<Person>();

            while (comands[0] != "End")
            {
                Person person = new Person(comands[0], comands[1], int.Parse(comands[2]));
                personList.Add(person);

                comands = Console.ReadLine().Split();
            }

            personList.OrderBy(person => person.Age).ToList().ForEach(person => Console.WriteLine(person));
        }
    }

    class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public override string ToString() => $"{Name} with ID: {Id} is {Age} years old.";
    }
}
