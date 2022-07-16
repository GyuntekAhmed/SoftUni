using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("\\");
            int lenght = input.Length;
            string nameWithExtention = input[lenght - 1];
            string[] words = nameWithExtention.Split('.');
            string fileName = words[0];
            string extention = words[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extention}");
        }
    }
}
