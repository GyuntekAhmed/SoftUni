using System;

namespace Animals
{
    public class StartUp
    {
        static void Main()
        {

            while (true)
            {
                Animals animals = default;
                string commands = Console.ReadLine();

                if (commands == "Beast!")
                {
                    break;
                }

                string typeOfAnimal = commands;
                string[] tokens = Console.ReadLine().Split();
                string nameOfAnimal = tokens[0];
                int ageOfAnimal = int.Parse(tokens[1]);

                if (ageOfAnimal < 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                switch (typeOfAnimal)
                {
                    case "Dog":
                        animals = new Dog(nameOfAnimal, ageOfAnimal, tokens[2]);
                        break;
                    case "Cat":
                        animals = new Cat(nameOfAnimal, ageOfAnimal, tokens[2]);
                        break;
                    case "Kitten":
                        animals = new Kitten(nameOfAnimal, ageOfAnimal);
                        break;
                    case "Tomcat":
                        animals = new Tomcat(nameOfAnimal, ageOfAnimal);
                        break;
                    case "Frog":
                        animals = new Frog(nameOfAnimal, ageOfAnimal, tokens[2]);
                        break;
                }
                Console.WriteLine(typeOfAnimal);
                Console.WriteLine($"{animals.Name} {animals.Age} {animals.Gender}");
                string sound = animals.ProduceSound();
                Console.WriteLine(sound);
            }
        }
    }
}
