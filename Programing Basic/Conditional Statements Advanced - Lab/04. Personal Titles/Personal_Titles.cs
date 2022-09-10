using System;

class Personal_Titles
{
    static void Main()
    {
        //            •	"Mr." – мъж(пол 'm') на 16 или повече години
        //•	"Master" – момче(пол 'm') под 16 години
        //•	"Ms." – жена(пол 'f') на 16 или повече години
        //•	"Miss" – момиче(пол 'f') под 16 години

        double age = double.Parse(Console.ReadLine());
        string gender = Console.ReadLine();

        if (gender == "f")
        {
            if (age < 16)
            {
                Console.WriteLine("Miss");
            }
            else
            {
                Console.WriteLine("Ms.");
            }
        }
        else if (gender == "m")
        {
            if (age < 16)
            {
                Console.WriteLine("Master");
            }
            else
            {
                Console.WriteLine("Mr.");
            }
        }
        else
        {
            Console.WriteLine("unknown");
        }
    }
}
