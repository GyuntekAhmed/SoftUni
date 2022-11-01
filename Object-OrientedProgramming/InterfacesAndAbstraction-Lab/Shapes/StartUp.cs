using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main()
        {
            int radius = int.Parse(Console.ReadLine());
            IDrawable circle = new Circle(radius);

            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            IDrawable reactangle = new Rectangle(width, height);

            circle.Draw();
            reactangle.Draw();
        }
    }
}
