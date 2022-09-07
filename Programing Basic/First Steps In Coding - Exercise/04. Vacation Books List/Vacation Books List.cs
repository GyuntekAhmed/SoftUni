using System;

class Vacation_Books_List

{
    static void Main()
    {
        int brstr = int.Parse(Console.ReadLine());
        int strcht = int.Parse(Console.ReadLine());
        int brdni = int.Parse(Console.ReadLine());
        int brchas;
        int neobhch;
        brchas = brstr / strcht;
        neobhch = brchas / brdni;
        Console.WriteLine(neobhch);
    }
}
