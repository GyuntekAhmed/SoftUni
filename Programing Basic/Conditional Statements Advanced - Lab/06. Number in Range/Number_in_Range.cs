using System;

class Number_in_Range
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        if (number >= -100)
        {
            if (number <= 100)

                if (number != 0)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }

            else
            {
                Console.WriteLine("No");
            }
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}
