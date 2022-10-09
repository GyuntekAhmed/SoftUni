using System;

namespace Touple
{
    public class StartUp
    {
        static void Main()
        {
            string[] personInfo = Console.ReadLine().Split();

            string fullName = $"{personInfo[0]} {personInfo[1]}";
            string city = $"{personInfo[2]}";

            string[] nameAndBeer = Console.ReadLine().Split();
            string name = nameAndBeer[0];
            int numberOfLitters = int.Parse(nameAndBeer[1]);

            string[] numbersInput = Console.ReadLine().Split();
            int intNum = int.Parse(numbersInput[0]);
            double doubleNum = double.Parse(numbersInput[1]);

            Tuple<string, string> firstTuple = new Tuple<string, string>(fullName, city);
            Tuple<string, int> secondTuple = new Tuple<string, int>(name, numberOfLitters);
            Tuple<int, double> thirdTuple = new Tuple<int, double>(intNum, doubleNum);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);

        }
    }
}
