using System;
using System.Text;

namespace _7._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatString(input,count));
        }

        static string RepeatString(string str,int count)
        {
            StringBuilder result = new StringBuilder();
            

            for (int i = 0; i < count; i++)
            {
                result.Append(str);
            }

            return result.ToString();
        }
    }
}
