using System;

namespace _1._Integer_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int fourthNum = int.Parse(Console.ReadLine());

            int sumNums = firstNum + secondNum;
            int divisionResult = sumNums / thirdNum;
            int multiplyResult = divisionResult * fourthNum;

            Console.WriteLine(multiplyResult);

        }
    }
}
