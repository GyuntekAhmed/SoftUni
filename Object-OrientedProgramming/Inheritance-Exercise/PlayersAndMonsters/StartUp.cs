using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main()
        {
            Hero hero = new Hero("Georgi", 100);

            Console.WriteLine(hero);
        }
    }
}
