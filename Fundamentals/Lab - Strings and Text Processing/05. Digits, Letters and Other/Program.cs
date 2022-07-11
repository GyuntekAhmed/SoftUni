using System;
using System.Text;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder letters = new StringBuilder();
            StringBuilder numbers = new StringBuilder();
            StringBuilder otherChars = new StringBuilder();

            string input = Console.ReadLine();

            foreach (char item in input)
            {
                if (char.IsDigit(item))
                {
                    otherChars.Append(item);
                }
                else if (char.IsLetter(item))
                {
                    letters.Append(item);
                }
                else
                {
                    numbers.Append(item);
                }
            }

            Console.WriteLine(otherChars);
            Console.WriteLine(letters);
            Console.WriteLine(numbers);
        }
    }
}
