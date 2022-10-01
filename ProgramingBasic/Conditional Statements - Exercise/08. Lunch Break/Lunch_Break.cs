using System;

class Lunch_Break
{
    static void Main()
    {
        //            Време за обяд: 96 * 1 / 8 = 12.0
        //Време за отдих: 96 * 1 / 4 = 24.0
        //Останало време : 96 - 12 - 24 = 60
        // 60
        // 96

        string nameofSerial = Console.ReadLine();
        int timeOfEpisode = int.Parse(Console.ReadLine());
        int timeOfBreak = int.Parse(Console.ReadLine());

        double timeForLunch = timeOfBreak * 0.125;
        double timeForRest = timeOfBreak * 0.25;
        double freeTime = timeOfBreak - (timeForLunch + timeForRest);

        if (freeTime >= timeOfEpisode)
        {
            Console.WriteLine($"You have enough time to watch {nameofSerial} and left with" + $" {Math.Ceiling(freeTime - timeOfEpisode)} minutes free time.");
        }
        else
        {
            Console.WriteLine($"You don't have enough time to watch {nameofSerial}, " + $"you need {Math.Ceiling(timeOfEpisode - freeTime)} more minutes.");
        }
    }
}
