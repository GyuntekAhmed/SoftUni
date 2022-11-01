using System;

namespace Cars
{
    public class StartUp
    {
        static void Main()
        {
            ICar seat = new Seat("Leon", "Grey");
            ICar tesla = new Tesla("Model 3", "Red", 2);

            Console.WriteLine(seat.ToString());
            Console.WriteLine(seat.Start());
            Console.WriteLine(seat.Stop());

            Console.WriteLine();

            Console.WriteLine(tesla.Start());
            Console.WriteLine(tesla.Stop());
            Console.WriteLine(tesla.ToString());
        }
    }
}
