using System;

class Shopping
{
    static void Main()
    {
        double cenavideokarta = 250;
        double kraynaCena = 0;

        double budjet = double.Parse(Console.ReadLine());
        double brVideokarti = double.Parse(Console.ReadLine());
        double brProcesor = double.Parse(Console.ReadLine());
        double brRam = double.Parse(Console.ReadLine());

        double sumaVideokarti = brVideokarti * cenavideokarta;
        double cenaProcesor = 0.35 * sumaVideokarti;
        double sumaProcesor = brProcesor * cenaProcesor;
        double cenaRam = 0.1 * sumaVideokarti;
        double sumaRam = brRam * cenaRam;
        double obshtaSuma = sumaVideokarti + sumaProcesor + sumaRam;

        if (brVideokarti > brProcesor)
        {
            double otstapka = 0.15 * obshtaSuma;
            kraynaCena = obshtaSuma - otstapka;
        }
        else
        {
            kraynaCena = obshtaSuma;
        }

        if (kraynaCena > budjet)
        {
            Console.WriteLine($"Not enough money! You need {Math.Abs(budjet - kraynaCena):f2} leva more!");
        }
        else
        {
            Console.WriteLine($"You have {Math.Abs(budjet - kraynaCena):f2} leva left!");
        }
    }
}
