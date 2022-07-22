using System;
using System.Threading;

namespace Morse_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();

            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                char testletter = input[i];

                switch (testletter)
                {
                    case 'A': result += ".-"; break;
                    case 'B': result += "-..."; break;
                    case 'C': result += "-.-."; break;
                    case 'D': result += "-.."; break;
                    case 'E': result += "."; break;
                    case 'F': result += "..-."; break;
                    case 'G': result += "--."; break;
                    case 'H': result += "...."; break;
                    case 'I': result += ".."; break;
                    case 'J': result += ".---"; break;
                    case 'K': result += "-.-"; break;
                    case 'L': result += ".-.."; break;
                    case 'M': result += "--"; break;
                    case 'N': result += "-."; break;
                    case 'O': result += "--.-"; break;
                    case 'P': result += ".--."; break;
                    case 'Q': result += "--.-"; break;
                    case 'R': result += ".-."; break;
                    case 'S': result += "..."; break;
                    case 'T': result += "-"; break;
                    case 'U': result += "..--"; break;
                    case 'V': result += "...-"; break;
                    case 'W': result += ".--"; break;
                    case 'X': result += "-.."; break;
                    case 'Y': result += "-.--"; break;
                    case 'Z': result += "--.."; break;

                    default: result += "/"; break;
                }
            }

            for (int i = 0; i < result.Length; i++)
            {
                Playsong(result[i]);
            }

            Console.WriteLine(result);
        }

        public static void Playsong(char testchar)
        {
            int freq = 500;
            int duration = 500;

            switch (testchar)
            {
                case '.':
                    Console.Beep(freq, duration);
                    break;
                case '-':
                    Console.Beep(freq, duration * 2);
                    break;
                case '/':
                    Thread.Sleep(20);
                    break;
            }
        }
    }
}
