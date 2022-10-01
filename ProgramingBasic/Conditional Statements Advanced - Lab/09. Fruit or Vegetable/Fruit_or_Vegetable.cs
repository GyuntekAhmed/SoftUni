using System;

class Fruit_or_Vegetable
{
    static void Main()
    {
        //tomato, cucumber, pepper и carrot

        string productName = Console.ReadLine();
        switch (productName)
        {
            case "banana":
            case "apple":
            case "kiwi":
            case "cherry":
            case "lemon":
            case "grapes":

                Console.WriteLine("fruit");
                break;
            case "tomato":
            case "cucumber":
            case "pepper":
            case "carrot":
                Console.WriteLine("vegetable");
                break;
            default:
                Console.WriteLine("unknown");
                break;
        }
    }
}
