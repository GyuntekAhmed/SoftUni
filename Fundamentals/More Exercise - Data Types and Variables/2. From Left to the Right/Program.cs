using System;
using System.Linq;

namespace _2._From_Left_to_the_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < numberOfLines; i++)
            {
                string stringNumbers = Console.ReadLine();
                string[] splitNumber = stringNumbers.Split(' ');


                long leftNum = long.Parse(splitNumber[0]);
                long rihtNum = long.Parse(splitNumber[1]);

                long biggerNum = leftNum;

                if (rihtNum>leftNum)
                {
                    biggerNum = rihtNum;
                }

                long sumOfDigits = 0;

                while (biggerNum != 0)
                {
                    sumOfDigits += biggerNum % 10;
                    biggerNum /= 10;
                }

                Console.WriteLine(Math.Abs(sumOfDigits));
            }
        }
    }
}
