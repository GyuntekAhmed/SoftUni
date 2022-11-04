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
            List<Pet> pets = new List<Pet>();
            

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split();

                if (tokens[0] == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthdate = tokens[4];

                    Citizens citizen = new Citizens(name, age, id, birthdate);
                    citizens.Add(citizen);
                }
                else if (tokens[0] == "Robot")
                {
                    string model = tokens[1];
                    string id = tokens[2];

                    Robots robot = new Robots(model, id);
                    robots.Add(robot);
                }
                else if (tokens[0] == "Pet")
                {
                    string name = tokens[1];
                    string birthdate = tokens[2];
                    Pet pet = new Pet(name, birthdate);
                    pets.Add(pet);
                    
                }
            }

            string lastDigitOfBirthdate = Console.ReadLine();

            foreach (var citizen in citizens)
            {
                string currentId = citizen.Birthdates;

                if (currentId.EndsWith(lastDigitOfBirthdate))
                {
                    fakeId.Add(currentId);
                }
            }

            //foreach (var robot in robots)
            //{
            //    string currentId = robot.Id;

            //    if (currentId.EndsWith(lastDigitOfFakeId))
            //    {
            //        fakeId.Add(currentId);
            //    }
            //}
            
            foreach (var pet in pets)
            {
                string currentId = pet.Birthdate;

                if (currentId.EndsWith(lastDigitOfBirthdate))
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
