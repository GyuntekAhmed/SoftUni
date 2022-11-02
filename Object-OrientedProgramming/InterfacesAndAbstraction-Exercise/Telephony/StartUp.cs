using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main()
        {
            Smartphone smartphone = new Smartphone("Nokia");
            string[] phones = Console.ReadLine().Split();

            foreach (var phone in phones)
            {
                if (phone.Length == 10)
                {
                    Console.WriteLine(smartphone.PhoneNumber(phone));
                }
                else
                {
                    Console.WriteLine($"Dialing... {phone}");
                }
            }
            string[] websites = Console.ReadLine().Split();
            foreach (var website in websites)
            {
                Console.WriteLine(smartphone.Website(website));
            }
        }
    }
}
