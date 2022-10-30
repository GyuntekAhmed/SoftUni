using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main()
        {
            string[] pizzaIngo = Console.ReadLine()
                .ToLower()
                .Split();
            string name = pizzaIngo[1];

            string[] doughInfo = Console.ReadLine()
                .ToLower()
                .Split();
            string flourType = doughInfo[1];
            string backingTehnique = doughInfo[2];
            int weight = int.Parse(doughInfo[3]);

            try
            {
                Dough dough = new Dough(flourType, backingTehnique, weight);
                Pizza pizza = new Pizza(name, dough);

                while (true)
                {
                    string input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }

                    string[] tokens = input.Split();

                    string typeOfToping = tokens[1];
                    int weightOfToping = int.Parse(tokens[2]);

                    Topping topping = new Topping(typeOfToping, weightOfToping);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
