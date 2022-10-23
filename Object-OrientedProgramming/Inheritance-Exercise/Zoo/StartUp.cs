using System;
using System.Collections.Generic;

namespace Zoo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<object> animals = new List<object>();
            List<string> names = new List<string>();

            while (true)
            {
                string tokens = Console.ReadLine();
                if (tokens == "end")
                {
                    break;
                }
                string name = tokens;
                names.Add(name);

            }

            Bear bear = new Bear(names[0]);
            animals.Add(bear);
            Gorilla gorilla = new Gorilla(names[1]);
            animals.Add(gorilla);
            Snake snake = new Snake(names[2]);
            animals.Add(snake);
            Lizard lizard = new Lizard(names[3]);
            animals.Add(lizard);

        }
    }
}
