using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            Person person = new Person("Gyintek", 31);

            Person person1 = new Person()
            {
                Name = "Gyuni",
                Age = 7,
            };
            Person person2 = new Person();
            person2.Name = "Georgi";
            person2.Age = 31;

            Console.WriteLine($"Name: {person.Name} Age: {person.Age}");
            Console.WriteLine($"Name: {person1.Name} Age: {person1.Age}");
            Console.WriteLine($"Name: {person2.Name} Age: {person2.Age}");
        }
    }
}
