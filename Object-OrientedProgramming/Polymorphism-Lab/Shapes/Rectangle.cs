namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get; protected set; }
        public double Width { get; protected set; }

        public override double CalculateArea() => Height * Width;

        public override double CalculatePerimeter() => (2 * Height) + (2 * Width);

        public override string Draw() => base.Draw() + GetType().Name;
    }
}
