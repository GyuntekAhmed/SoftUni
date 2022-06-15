using System;

namespace _03._Longer_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            LongestLine(x1, y1, x2, y2, x3, y3, x4, y4);
        }

        static void LongestLine(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double firstLine = Math.Sqrt(Math.Pow(Math.Abs(x1 - x2), 2) + Math.Pow(Math.Abs(y1 - y2), 2));
            double secondLine = Math.Sqrt(Math.Pow(Math.Abs(x3 - x4), 2) + Math.Pow(Math.Abs(y3 - y4), 2));

            if (firstLine >= secondLine)
            {
                CloseToZero(x1, y1, x2, y2);
            }
            else
            {
                CloseToZero(x3, y3, x4, y4);
            }
        }

        static void CloseToZero(double x1, double y1, double x2, double y2)
        {
            double first = Math.Sqrt(Math.Pow(Math.Abs(x1), 2) + Math.Pow(Math.Abs(y1), 2));
            double second = Math.Sqrt(Math.Pow(Math.Abs(x2), 2) + Math.Pow(Math.Abs(y2), 2));

            if (first > second)
            {
                Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            }
        }
    }
    }
