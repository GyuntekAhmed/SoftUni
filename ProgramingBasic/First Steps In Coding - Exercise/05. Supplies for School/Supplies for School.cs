using System;

class Supplies_for_School
{
    static void Main(string[] args)
    {
        double cenahimikali = 5.80;
        double cenamarkeri = 7.20;
        double cenapreparat = 1.20;
        int himikali = int.Parse(Console.ReadLine());
        int markeri = int.Parse(Console.ReadLine());
        int litripr = int.Parse(Console.ReadLine());
        double namalenie = double.Parse(Console.ReadLine());
        namalenie /= 100;
        double sumahimikali;
        double sumamarkeri;
        double sumapr;
        sumahimikali = himikali * cenahimikali;
        sumamarkeri = markeri * cenamarkeri;
        sumapr = litripr * cenapreparat;
        double sumavsichko;
        sumavsichko = sumahimikali + sumamarkeri + sumapr;
        double cenanamal;
        cenanamal = sumavsichko - (sumavsichko * namalenie);

        Console.WriteLine(cenanamal);
    }
}
