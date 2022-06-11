using System;

namespace _07._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfMatrix = int.Parse(Console.ReadLine());

            PrintMatrix(countOfMatrix);
        }

        private static void PrintMatrix(int count)
        {
            for (int rows = 0; rows < count; rows++)
            {
                for (int cols = 0; cols < count; cols++)
                {
                    Console.Write(count + " ");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
