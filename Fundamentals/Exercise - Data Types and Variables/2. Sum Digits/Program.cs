using System;

namespace _2._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            // first try to solve the problem

            //int num = int.Parse(Console.ReadLine());
            //int sum = 0;

            //while (num != 0)
            //{
            //    int lastDigit = num % 10;
            //    sum += lastDigit;
            //    num /= 10;
            //}
            //Console.WriteLine(sum);

            // second try to solve the problem

            string input = Console.ReadLine();
            int sum = 0;
            // char[] charArray = input.ToCharArray();

            //for (int value = 0; value < charArray.Length; value++)
            //{
            //    sum += int.Parse(charArray[value].ToString());
            //}
            //Console.WriteLine(sum);

            // third try to solve the problem

            for (int i = 0; i < input.Length; i++)
            {
                sum += int.Parse(input[i].ToString());
            }
            Console.WriteLine(sum);
        }
    }
}
