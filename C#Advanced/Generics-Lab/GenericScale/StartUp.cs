using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main()
        {
            EqualityScale<int> nums = new EqualityScale<int>(5, 5);

            int num1 = 54;
            int num2 = 46;

            var result = nums.Equals(num1 == num2);

            Console.WriteLine(nums.AreEqual());

            Console.WriteLine(result);
        }
    }
}
