using System;
using System.Collections.Generic;
using System.Linq;

class _Fashion_Boutique
{
    static void Main()
    {
        Stack<int> clothesInBox = new Stack<int>(Console.ReadLine()
            .Split(' ')
            .Select(int.Parse));
        int capacity = int.Parse(Console.ReadLine());

        int racks = 1;
        int stack = 0;

        int countOfClothes = clothesInBox.Count;

        for (int i = 0; i < countOfClothes; i++)
        {
            int currentCloth = clothesInBox.Peek();

            if (stack + currentCloth <= capacity)
            {
                stack += currentCloth;
                clothesInBox.Pop();
            }
            else
            {
                stack = 0;
                stack = currentCloth;
                racks++;
                clothesInBox.Pop();
            }
        }

        Console.WriteLine(racks);
    }
}
