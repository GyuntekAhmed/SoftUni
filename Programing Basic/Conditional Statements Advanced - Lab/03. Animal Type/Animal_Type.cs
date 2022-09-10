using System;

class Animal_Type
{
    static void Main()
    {
        //            1.dog->mammal
        //2.crocodile, tortoise, snake->reptile
        //3.others->unknown

        string animal = Console.ReadLine();

        switch (animal)
        {
            case "dog":
                Console.WriteLine("mammal");
                break;
            case "crocodile":
            case "tortoise":
            case "snake":
                Console.WriteLine("reptile");
                break;
            default:
                Console.WriteLine("unknown");
                break;
        }
    }
}
