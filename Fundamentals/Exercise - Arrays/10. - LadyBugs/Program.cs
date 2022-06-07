using System;

namespace _10.___LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fileddSize = int.Parse(Console.ReadLine());

            int[] ladyBugsField = new int[fileddSize];

            string[] occupiedIndexes = Console.ReadLine().Split();

            for (int i = 0; i < occupiedIndexes.Length; i++)
            {
                int currIndex = int.Parse(occupiedIndexes[i]);

                if (currIndex >= 0 && currIndex < fileddSize)
                {
                    ladyBugsField[currIndex] = 1;
                }
            }

            string[] comands = Console.ReadLine().Split();

            while (comands[0] != "end")
            {
                bool isFurst = true;
                int currIndex = int.Parse(comands[0]);

                while (currIndex >= 0 && currIndex < fileddSize && ladyBugsField[currIndex] != 0)
                {
                    if (isFurst)
                    {
                        ladyBugsField[currIndex] = 0;
                        isFurst = false;
                    }

                    string direction = comands[1];
                    int flightLenght = int.Parse(comands[2]);

                    if (direction == "left")
                    {
                        currIndex -= flightLenght;
                        if (currIndex >= 0 && currIndex < fileddSize)
                        {

                            if (ladyBugsField[currIndex] == 0)
                            {
                                ladyBugsField[currIndex] = 1;
                                break;
                            }
                        }
                    }

                    else
                    {
                        currIndex += flightLenght;
                        if (currIndex>=0&&currIndex<fileddSize)
                        {
                            if (ladyBugsField[currIndex]==0)
                            {
                                ladyBugsField[currIndex] = 1;
                                break;
                            }
                        }
                    }

                }

                comands = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ",ladyBugsField));
        }
    }
}
