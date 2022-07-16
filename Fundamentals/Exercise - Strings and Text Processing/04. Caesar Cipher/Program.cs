using System;
using System.Text;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            StringBuilder encryptedText = new StringBuilder();

            for (int i = 0; i < message.Length; i++)
            {
                char enctyptedChar = (char)(message[i] + 3);

                encryptedText.Append(enctyptedChar);
            }

            Console.WriteLine(encryptedText);
        }
    }
}
