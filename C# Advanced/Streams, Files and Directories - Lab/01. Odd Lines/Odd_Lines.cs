using System;
using System.IO;

class Odd_Lines
{
    static void Main()
    {
        var reader = new StreamReader("../../../input.txt");
        using (reader)
        {
            var writer = new StreamWriter("../../../output.txt");
            using(writer)
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
                }
            }
        }
    }
}
