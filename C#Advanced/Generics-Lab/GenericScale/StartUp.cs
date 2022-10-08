using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main()
        {
            EqualityScale<int> nums = new EqualityScale<int>();

            int num1 = 5;
            int num2 = 6;

            var result = nums.Equals(num1 == num2);

            Console.WriteLine(result);
        }
    }
}
