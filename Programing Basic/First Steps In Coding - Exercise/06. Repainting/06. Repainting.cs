using System;

internal class Repainting
{
    static void Main(string[] args)
    {
        double CenaNaylon = 1.50;
        double CenaBoq = 14.50;
        double CenaRazreditel = 5.00;
        double Torbichki = 0.40;
        double ProcentDopalnBoq = 1.1;
        int DopalnNaylon = 2;

        int KolNaylon = int.Parse(Console.ReadLine());
        int KolBoq = int.Parse(Console.ReadLine());
        int KolRazreditel = int.Parse(Console.ReadLine());
        int Casove = int.Parse(Console.ReadLine());

        int ObshtoNaylon = KolNaylon + DopalnNaylon;
        double ObshtoBoq = KolBoq * ProcentDopalnBoq;

        double SumaNaylon = ObshtoNaylon * CenaNaylon;
        double SumaBoq = ObshtoBoq * CenaBoq;
        double SumaRazreditel = KolRazreditel * CenaRazreditel;

        double ObshtaSumaMateriali = SumaNaylon + SumaBoq + SumaRazreditel + Torbichki;
        double CenaMaystori = 0.3 * ObshtaSumaMateriali;
        double SumaMaystori = CenaMaystori * Casove;
        double KraynaSumaRazhodi = ObshtaSumaMateriali + SumaMaystori;
        Console.WriteLine(KraynaSumaRazhodi);
    }
}
