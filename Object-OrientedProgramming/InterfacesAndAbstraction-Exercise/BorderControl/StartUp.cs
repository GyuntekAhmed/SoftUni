using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main()
        {
            List<string> fakeId = new List<string>();
            List<Citizens> citizens = new List<Citizens>();
            List<Robots> robots = new List<Robots>();
            

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split();

                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];

                    Citizens citizen = new Citizens(name, age, id);
                    citizens.Add(citizen);
                }
                else if (tokens.Length == 2)
                {
                    string model = tokens[0];
                    string id = tokens[1];

                    Robots robot = new Robots(model, id);
                    robots.Add(robot);
                }
            }

            string lastDigitOfFakeId = Console.ReadLine();

            foreach (var citizen in citizens)
            {
                string currentId = citizen.Id;

                if (currentId.EndsWith(lastDigitOfFakeId))
                {
                    fakeId.Add(currentId);
                }
            }

            foreach (var robot in robots)
            {
                string currentId = robot.Id;

                if (currentId.EndsWith(lastDigitOfFakeId))
                {
                    fakeId.Add(currentId);
                }
            }

            foreach (var id in fakeId.OrderBy(x => x.Length))
            {
                Console.WriteLine(id);
            }
        }
    }
}
