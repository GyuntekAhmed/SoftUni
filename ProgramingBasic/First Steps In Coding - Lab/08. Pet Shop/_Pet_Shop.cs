using System;

namespace _08._Pet_Shop
{
    class _Pet_Shop
    {
        static void Main(string[] args)
        {
            double dogs = 2.5;
            int cats = 4;
            int prc = int.Parse(Console.ReadLine());
            int prs = int.Parse(Console.ReadLine());
            double sume = prc * dogs + prs * cats;
            Console.WriteLine($"{sume} lv.");
        }
    }
}
