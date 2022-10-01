using System;

internal class Food_Delivery
{
    static void Main()
    {
        double CenaPilMenu = 10.35;
        double CenaRibaMenu = 12.40;
        double CenaVegMenu = 8.15;
        double ProcentDesert = 0.2;
        double Dostavka = 2.50;

        int BrPilMenu = int.Parse(Console.ReadLine());
        int BrRibaMenu = int.Parse(Console.ReadLine());
        int BrVegMenu = int.Parse(Console.ReadLine());

        double SumaCenaPilMenu = BrPilMenu * CenaPilMenu;
        double SumaCenaRibaMenu = BrRibaMenu * CenaRibaMenu;
        double SumaCenaVegMenu = BrVegMenu * CenaVegMenu;
        double ObshtaCenaMenu = SumaCenaPilMenu + SumaCenaRibaMenu + SumaCenaVegMenu;
        double CenaDesert = ProcentDesert * ObshtaCenaMenu;
        double ObshtaCenaPorachka = ObshtaCenaMenu + CenaDesert + Dostavka;
        Console.WriteLine(ObshtaCenaPorachka);
    }
}
