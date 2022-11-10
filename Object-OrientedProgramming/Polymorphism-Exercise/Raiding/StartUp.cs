using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main()
        {
            long sumOfAllPowers = 0;
            List<BaseHero> heroes = new List<BaseHero>();

            int countOfHeroes = int.Parse(Console.ReadLine());

            while (heroes.Count != countOfHeroes)
            {
                string nameOfHero = Console.ReadLine();
                string typeOfHero = Console.ReadLine();

                if (typeOfHero == "Druid")
                {
                    Druid druid = new Druid(nameOfHero);
                    heroes.Add(druid);
                }
                else if (typeOfHero == "Paladin")
                {
                    Paladin paladin = new Paladin(nameOfHero);
                    heroes.Add(paladin);
                }
                else if (typeOfHero == "Rogue")
                {
                    Rogue rogue = new Rogue(nameOfHero);
                    heroes.Add(rogue);
                }
                else if (typeOfHero == "Warrior")
                {
                    Warrior warrior = new Warrior(nameOfHero);
                    heroes.Add(warrior);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            sumOfAllPowers = heroes.Select(h => h.Power).Sum();

            long bossPower = long.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            if (sumOfAllPowers < bossPower)
            {
                Console.WriteLine("Defeat...");
            }
            else
            {
                Console.WriteLine("Victory!");
            }
        }
    }
}
