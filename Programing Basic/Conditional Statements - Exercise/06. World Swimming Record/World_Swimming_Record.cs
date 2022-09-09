using System;

class World_Swimming_Record
{
    static void Main()
    {
        double rekord = double.Parse(Console.ReadLine());
        double razstoqnie = double.Parse(Console.ReadLine());
        double vreme = double.Parse(Console.ReadLine());

        double sekundiZaPluvane = razstoqnie * vreme;
        double dobavka = Math.Floor(razstoqnie / 15);
        double saprotivlenie = dobavka * 12.5;
        double obshtovreme = sekundiZaPluvane + saprotivlenie;

        if (obshtovreme < rekord)
        {
            Console.WriteLine($" Yes, he succeeded! The new world record is {obshtovreme:f2} seconds.");
        }
        else
        {
            double nedostig = obshtovreme - rekord;
            Console.WriteLine($"No, he failed! He was {nedostig:f2} seconds slower.");
        }
    }
}
