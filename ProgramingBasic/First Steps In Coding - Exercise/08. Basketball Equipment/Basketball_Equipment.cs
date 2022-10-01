using System;

internal class Basketball_Equipment
{
    static void Main()
    {
        /*•	Баскетболни кецове – цената им е 40% по-малка от таксата за една година
•	Баскетболен екип – цената му е 20% по-евтина от тази на кецовете
•	Баскетболна топка – цената ѝ е 1 / 4 от цената на баскетболния екип
•	Баскетболни аксесоари – цената им е 1 / 5 от цената на баскетболната топка
*/
        double Procent40 = 0.4;
        double Procent20 = 0.2;
        double Procent25 = 0.25;

        int GodishnaTaksa = int.Parse(Console.ReadLine());

        double CenaKecove = GodishnaTaksa - GodishnaTaksa * Procent40;
        double CenaEkip = CenaKecove - CenaKecove * Procent20;
        double CenaTopka = CenaEkip * Procent25;
        double CenaAksesoari = CenaTopka * Procent20;
        double ObshtaCena = GodishnaTaksa + CenaKecove + CenaEkip + CenaTopka + CenaAksesoari;
        Console.WriteLine(ObshtaCena);
    }
}
