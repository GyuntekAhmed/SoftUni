using System;

class Toy_Shop
{
    static void Main()
    {
        double puzelCena = 2.60;
        int govKuklaCena = 3;
        double plushMecheCena = 4.10;
        double minionCena = 8.20;
        int kamioncheCena = 2;
        double otstapka = 0;


        double cenaEkzkurzia = double.Parse(Console.ReadLine());
        int brPuzeli = int.Parse(Console.ReadLine());
        int brGovKukli = int.Parse(Console.ReadLine());
        int brPlushMecheta = int.Parse(Console.ReadLine());
        int brMinioni = int.Parse(Console.ReadLine());
        int brKamioncheta = int.Parse(Console.ReadLine());

        int brIgracjki = 
            brPuzeli + brGovKukli + brPlushMecheta + 
            brMinioni + brKamioncheta;
        double suma = 
            brPuzeli * puzelCena + brGovKukli 
            * govKuklaCena + brPlushMecheta 
            * plushMecheCena + brMinioni 
            * minionCena + brKamioncheta * kamioncheCena;

        if (brIgracjki >= 50)
        {
            otstapka = suma - (suma * 0.75);
        }

        double kraynaCena = suma - otstapka;
        double naem = kraynaCena - kraynaCena * 0.9;
        double pechalba = kraynaCena - naem;

        if (pechalba >= cenaEkzkurzia)
        {
            Console.WriteLine($"Yes! {pechalba - cenaEkzkurzia:f2} lv left.");
        }
        else
        {

            Console.WriteLine($"Not enough money! {Math.Abs(pechalba - cenaEkzkurzia):f2} lv needed.");
        }
    }
}
