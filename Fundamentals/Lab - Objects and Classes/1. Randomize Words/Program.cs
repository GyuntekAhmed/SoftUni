using System;

namespace _1._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();
            Random random = new Random();

            for (int i = 0; i < strings.Length - 1; i++)
            {
                int swapPosition = random.Next(strings.Length);
                string temp = strings[i]; ;
                strings[i] = strings[swapPosition];
                strings[swapPosition] = temp;

            }

            Console.WriteLine(string.Join("\n", strings));
        }
    }
}
