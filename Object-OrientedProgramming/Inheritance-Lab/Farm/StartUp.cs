using System;

namespace Farm
{
    public class StartUp
    {
        static void Main()
        {
            Console.WriteLine("Dog:");

            Dog dog = new Dog();
            dog.Eat();
            dog.Bark();
            Console.WriteLine();

            Console.WriteLine("Cat:");

            Cat puppy = new Cat();
            puppy.Eat();
            puppy.Meow();
        }
    }
}
