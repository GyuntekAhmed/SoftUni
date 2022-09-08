using System;

class Area_of_Figures
{
    static void Main()
    {
        string figureType = Console.ReadLine();

        if (figureType == "square")
        {
            double a = double.Parse(Console.ReadLine());
            double area = a * a;
            Console.WriteLine($"{area:f3}");
        }
        else if (figureType == "rectangle")
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double area = a * b;
            Console.WriteLine($"{area:f3}");
        }
        else if (figureType == "circle")
        {
            double r = double.Parse(Console.ReadLine());
            double area = r * r * Math.PI;
            Console.WriteLine($"{area:f3}");
        }
        else if (figureType == "triangle")
        {
            double a = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double area = a * h / 2;
            Console.WriteLine($"{area}:f3");
        }
    }
}
