using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";
            RewriteFileWithLineNumbers(inputPath, outputPath);
        }
        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            using (reader)
            {
                StreamWriter writer = new StreamWriter(outputFilePath);
                using (writer)
                {
                    int lineNum = 0;
                    string line;

                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        writer.WriteLine(lineNum + ". " + line);
                        lineNum++;
                    }
                }
            }
        }
    }
}