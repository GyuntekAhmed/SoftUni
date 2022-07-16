using System;
using System.Text;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNum = Console.ReadLine();
            int secondNum = int.Parse(Console.ReadLine());

            if (secondNum == 0)
            {
                Console.WriteLine(0);
                return;
            }

            StringBuilder sb = new StringBuilder();
            int remeinder = 0;

            for (int i = firstNum.Length - 1; i >= 0; i--)
            {
                char lastNum = firstNum[i];
                int lastNumAsDigit = int.Parse(lastNum.ToString());

                int result = lastNumAsDigit * secondNum + remeinder;

                sb.Append(result % 10);
                remeinder = result / 10;
            }
            if (remeinder != 0)
            {
                sb.Append(remeinder);
            }

            StringBuilder reversedString = new StringBuilder();

            for (int i = sb.Length - 1; i >= 0; i--)
            {
                reversedString.Append(sb[i]);
            }

            Console.WriteLine(reversedString);
        }
    }
}
