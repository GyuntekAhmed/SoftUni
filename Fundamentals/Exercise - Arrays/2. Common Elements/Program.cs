using System;

namespace _2._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrOne = Console.ReadLine().Split(separator: ' ');
            string[] arrTwo = Console.ReadLine().Split(separator: ' ');

            foreach (string currElement in arrOne)
            {
                for (int i = 0; i < arrTwo.Length; i++)
                {
                    string secondCurrElement = arrTwo[i];

                    if (currElement == secondCurrElement)
                    {
                        Console.Write($"{currElement} ");
                        break;
                    }
                }
            }

        }
    }
}
