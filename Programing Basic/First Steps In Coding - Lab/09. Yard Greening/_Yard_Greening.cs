using System;

namespace _09._Yard_Greening
{
    class _Yard_Greening
    {
        static void Main(string[] args)
        {
            double dvor = double.Parse(Console.ReadLine());
            double kvm = 7.61;
            double Price = dvor * kvm;
            double discount = 0.18 * Price;
            double FinPrice = Price - discount;
            Console.WriteLine($"The final price is: {FinPrice} lv.");
            Console.WriteLine($"The discount is: {discount} lv.")
        }
    }
}
