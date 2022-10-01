using System;

class Invalid_Number
{
    static void Main()
    {

        int number = int.Parse(Console.ReadLine());

        if (number == 0)
        {
            Console.WriteLine("");
        }
        else if (number < 100 || number > 200)
        {
            Console.WriteLine("invalid");
        }
        else
        {
            Console.WriteLine("");
        }
    }
}
