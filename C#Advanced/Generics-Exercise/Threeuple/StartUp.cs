using System;

namespace Threeuple
{
    public class StartUp
    {
        static void Main()
        {
            string[] personInfo = Console.ReadLine().Split();

            string fullName = $"{personInfo[0]} {personInfo[1]}";
            string adress = $"{personInfo[2]}";
            string city = personInfo.Length > 4 ? $"{personInfo[3]} {personInfo[4]}" :
                $"{personInfo[3]}";

            string[] nameAndBeer = Console.ReadLine().Split();
            string name = nameAndBeer[0];
            int numberOfLitters = int.Parse(nameAndBeer[1]);
            bool isDrunken = nameAndBeer[2] == "drunk" ? true : false;

            string[] nameAndBank = Console.ReadLine().Split();
            string nameFromBank = nameAndBank[0];
            double accountBalance = double.Parse(nameAndBank[1]);
            string bankName = nameAndBank[2];


            Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>(fullName, adress, city);
            Threeuple<string, int, bool> secondTuple = new Threeuple<string, int, bool>(name, numberOfLitters, isDrunken);
            Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(nameFromBank, accountBalance, bankName);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
