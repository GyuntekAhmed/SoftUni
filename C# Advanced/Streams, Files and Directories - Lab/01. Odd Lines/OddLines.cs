using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        StreamReader reader = new("../../../input.txt");
        using (reader)
        {
            StreamWriter writer = new StreamWriter("../../../output.txt");
            using (writer)
            {
                int lineNum = 0;
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                        break;
                    if (lineNum % 2 == 1)
                    {
                        writer.WriteLine(line);
                    }
                    lineNum++;
                }
            }
        }
    }
}
