using System;

    class Program
    {
        static void Main()
        {
            string username = Console.ReadLine();
            string password = "";

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            int countOfWrongPass = 0;

            string inputPass = Console.ReadLine();

            while (inputPass != password)
            {
                countOfWrongPass++;

                if (countOfWrongPass > 3)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }
                Console.WriteLine("Incorrect password. Try again.");
                inputPass = Console.ReadLine();
            }

            if (inputPass == password)
            {
                Console.WriteLine($"User {username} logged in.");
            }


        }
    }
