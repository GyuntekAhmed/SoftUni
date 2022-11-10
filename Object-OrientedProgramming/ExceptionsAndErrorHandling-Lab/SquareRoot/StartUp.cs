using System;

namespace SquareRoot
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    throw new ArithmeticException("Invalid number.");
                }
                double sqr = Math.Sqrt(number);

                Console.WriteLine(sqr);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
