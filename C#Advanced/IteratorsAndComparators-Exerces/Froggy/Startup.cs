using System;
using System.Linq;

namespace Froggy
{
    public class Startup
    {
        static void Main()
        {
            var lake = new Lake(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
