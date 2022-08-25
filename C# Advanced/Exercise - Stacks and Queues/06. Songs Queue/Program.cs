using System;
using System.Collections.Generic;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", "));

            while (songs.Count > 0)
            {
                string command = Console.ReadLine();
                if (command.Contains("Add"))
                {
                    command = command.Remove(0, 4);
                    string nameOfSong = command;
                    if (songs.Contains(nameOfSong))
                    {
                        Console.WriteLine($"{nameOfSong} is already contained!");
                        continue;
                    }
                    songs.Enqueue(nameOfSong);
                }
                else if (command == "Play")
                {
                    songs.Dequeue();
                }
                else
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
