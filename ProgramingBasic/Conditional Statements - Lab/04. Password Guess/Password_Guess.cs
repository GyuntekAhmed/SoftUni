using System;

class Password_Guess
{
    static void Main()
    {
        string password = Console.ReadLine();
        string Key = "s3cr3t!P@ssw0rd";


        if (password == Key)
        {
            Console.WriteLine("Welcome");
        }
        else
        {
            Console.WriteLine("Wrong password!");
        }
    }
}
