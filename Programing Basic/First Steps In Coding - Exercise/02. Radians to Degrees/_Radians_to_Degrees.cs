using System;

namespace _02._Radians_to_Degrees
{
    class _Radians_to_Degrees
    {
        static void Main(string[] args)
        {
            double radiani = double.Parse(Console.ReadLine());
            double gradusi;
            gradusi = radiani * 180 / 3.1415926535897932384626433;
            Console.WriteLine(gradusi);

        }
    }
}
