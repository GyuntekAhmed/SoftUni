using System;

class Deposit_Calculator
{
    static void Main()
    {
        double deposit = double.Parse(Console.ReadLine());
        int srok = int.Parse(Console.ReadLine());
        double lihva1 = double.Parse(Console.ReadLine());
        double suma;
        double newlihva;
        double lihva2;
        lihva1 /= 100;
        lihva2 = deposit * lihva1;
        newlihva = lihva2 / 12;

        suma = deposit + (srok * newlihva);
        Console.WriteLine(suma);
    }
}
