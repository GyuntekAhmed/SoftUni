using System;
using System.Linq;


class Jagged_Array_Modification
{
    static void Main()
    {
        // Read a jagged array
        int rows = int.Parse(Console.ReadLine());
        int[][] jaggedArr = new int[rows][];

        for (int row = 0; row < rows; row++)
        {
            jaggedArr[row] = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
        }
        // Execute the commands
        while (true)
        {
            string[] command = Console.ReadLine().Split();

            if (command[0] == "END")
            {
                break;
            }
            int row = int.Parse(command[1]);
            int col = int.Parse(command[2]);
            int value = int.Parse(command[3]);

            if (row >= 0 && row < jaggedArr.Length && col >= 0 && col < jaggedArr[row].Length)
            {
                if (command[0] == "Add")
                {
                    jaggedArr[row][col] += value;
                }
                else
                {
                    jaggedArr[row][col] -= value;
                }
            }
            else
            {
                Console.WriteLine("Invalid coordinates");
            }
        }

        // Print the jagged array
        for (int row = 0; row < jaggedArr.Length; row++)
        {
            Console.WriteLine(string.Join(" ", jaggedArr[row]));
        }
    }
}
