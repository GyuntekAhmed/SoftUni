using System;

namespace _3._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            switch (comand)
            {
                case "add":
                    AddNum(firstNum, secondNum);
                    break;
                case "divide":
                    DivideNum(firstNum, secondNum);
                    break;
                case "multiply":
                    MultiplyNum(firstNum, secondNum);
                    break;
                case "subtract":
                    SubtractNum(firstNum, secondNum);
                    break;
            }
        }

        static void AddNum(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum + secondNum);
        }

        static void MultiplyNum(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum * secondNum);
        }

        static void SubtractNum(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum - secondNum);
        }

        static void DivideNum(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum / secondNum);
        }
    }
}
