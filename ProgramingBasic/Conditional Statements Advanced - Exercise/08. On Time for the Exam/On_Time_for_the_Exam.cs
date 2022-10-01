using System;

class On_Time_for_the_Exam
{
    static void Main()
    {
        int examHour = int.Parse(Console.ReadLine());
        int examMinutes = int.Parse(Console.ReadLine());
        int arrivalHour = int.Parse(Console.ReadLine());
        int arrivalMinutes = int.Parse(Console.ReadLine());

        int examTimeAsMinutes = examHour * 60 + examMinutes;
        int arrivalTimeAsMinutes = arrivalHour * 60 + arrivalMinutes;
        int diferenceExamArrival = examTimeAsMinutes - arrivalTimeAsMinutes;
        int diferenceHours = diferenceExamArrival / 60;
        int diferenceMinutes = diferenceExamArrival % 60;
        if (diferenceExamArrival == 0)
        {
            Console.WriteLine("On time");
        }
        else if (diferenceExamArrival > 0)
        {
            if (diferenceExamArrival <= 30)
            {
                Console.WriteLine("On time");
                Console.WriteLine($"{diferenceMinutes} minutes before the start");
            }
            else
            {
                Console.WriteLine("Early");

                if (diferenceHours <= 0)
                {
                    Console.WriteLine($"{diferenceMinutes} minutes before the start");
                }
                else
                {
                    Console.WriteLine($"{diferenceHours}:{diferenceMinutes:d2} hours before the start");
                }
            }
        }
        else if (diferenceExamArrival < 0)
        {
            Console.WriteLine("Late");
            if (diferenceHours == 0)
            {
                Console.WriteLine($"{Math.Abs(diferenceMinutes)} minutes after the start");
            }
            else
            {
                Console.WriteLine($"{Math.Abs(diferenceHours)} {Math.Abs(diferenceMinutes):d2} hours after the start");
            }
        }
    }
}
