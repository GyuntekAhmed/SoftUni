using System;

class Program
{
    static void Main()
    {
        double budjet = double.Parse(Console.ReadLine());
        int brStatisti = int.Parse(Console.ReadLine());
        double cenaObleklo = double.Parse(Console.ReadLine());

        double procent = 0.1;
        double sumaDekor = budjet * procent;
        double sumaObleklo = brStatisti * cenaObleklo;
        if (brStatisti > 150)
        {
            double otstapka = sumaObleklo * procent;
            sumaObleklo = sumaObleklo - otstapka;
        }
        double obshtoSumaZaFilma = sumaDekor + sumaObleklo;
        double ostatak = budjet - obshtoSumaZaFilma;
        ostatak = Math.Abs(ostatak);
        if (obshtoSumaZaFilma > budjet)
        {
            Console.WriteLine("Not enough money!");
            Console.WriteLine($"Wingard needs {ostatak:f2} leva more.");
        }
        else if (obshtoSumaZaFilma <= budjet)
        {
            double nedostig = obshtoSumaZaFilma - budjet;
            nedostig = Math.Abs(nedostig);
            Console.WriteLine("Action!");
            Console.WriteLine($"Wingard starts filming with {nedostig:f2} leva left.");
        }
    }
}
