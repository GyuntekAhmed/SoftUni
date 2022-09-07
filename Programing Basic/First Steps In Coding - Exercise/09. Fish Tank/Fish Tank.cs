using System;
class Fish_Tank
{
    static void Main()
    {
        double decimeterDivider = 10;
        double percentDivider = 100;

        int lenghtInCm = int.Parse(Console.ReadLine());
        int widthInCm = int.Parse(Console.ReadLine());
        int heightInCm = int.Parse(Console.ReadLine());
        double accessoriesVolumeNum = double.Parse(Console.ReadLine());


        double lenghtInDm = lenghtInCm / decimeterDivider;
        double widthInDm = widthInCm / decimeterDivider;
        double heightInDm = heightInCm / decimeterDivider;

        double accessoriesVolumePercentage = accessoriesVolumeNum / percentDivider;

        double totalVolume = lenghtInDm * widthInDm * heightInDm;

        double accessoriesVolume = totalVolume * accessoriesVolumePercentage;
        double watterVolume = totalVolume - accessoriesVolume;
        Console.WriteLine(watterVolume);
    }
}
