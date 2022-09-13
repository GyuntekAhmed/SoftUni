using System;
using System.Collections.Generic;

class Crossroads
{
    static void Main()
    {
        int greenLineSeconds = int.Parse(Console.ReadLine());
        int freeWindowSeconds = int.Parse(Console.ReadLine());

        int totalCarsPassed = 0;
        string crashedCar = string.Empty;

        Queue<char> cars = new Queue<char>();

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "END")
            {
                break;
            }
            else if (command == "green")
            {

            }
            else
            {
                foreach (char ch in command)
                {
                    cars.Enqueue(ch);
                }
            }

        }
    }
}
