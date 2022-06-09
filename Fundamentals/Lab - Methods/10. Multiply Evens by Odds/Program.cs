using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            numbers = Math.Abs(numbers);

            int sumOfEven = GetSumOfEven(numbers);
            int sumOfOdd = GetSumOfOddDigits(numbers);
            int result = GetMultipleOfEvenAndOdds(sumOfEven, sumOfOdd);

            Console.WriteLine(result);
        }

        static int GetSumOfEven(int number)
        {
            int sum = 0;
            int digits = number;

            while (digits > 0)
            {
                int currentDigit = digits % 10;

                if (currentDigit % 2 == 0)
                {
                    sum += currentDigit;
                }

                digits /= 10;
            }

            return sum;
        }

        static int GetSumOfOddDigits(int number)
        {
            int sum = 0;
            int digit = number;


            while (digit > 0)
            {
                int currentDigit = digit % 10;

                if (currentDigit % 2 != 0)
                {
                    sum += currentDigit;
                }

                digit /= 10;
            }
            return sum;
        }

        static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            return evenSum * oddSum;
        }
    }
}
