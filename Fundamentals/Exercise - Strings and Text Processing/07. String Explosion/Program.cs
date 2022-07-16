using System;
using System.Text;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            int power = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char cuurent = input[i];

                if (cuurent == '>')
                {
                   power += int.Parse(input[i + 1].ToString());

                    sb.Append(cuurent);
                }
                else if (power == 0)
                {
                    sb.Append(cuurent);
                }
                else
                {
                    power--;
                }
            }

            Console.WriteLine(sb);
        }
    }
}
