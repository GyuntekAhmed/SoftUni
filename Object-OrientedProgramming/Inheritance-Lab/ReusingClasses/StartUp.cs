using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main()
        {
            RandomList list = new RandomList();

            list.Add("Georgi");
            list.Add("Jack");
            list.Add("Anna");
            list.Add("Eva");
            list.Add("Brath");

            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
        }
    }
}
