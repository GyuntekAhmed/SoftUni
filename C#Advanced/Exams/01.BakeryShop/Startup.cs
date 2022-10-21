using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace _01.BakeryShop
{
    internal class Startup
    {
        static void Main()
        {
            Dictionary<string, double> products = new Dictionary<string, double>()
            {
                {"Croissant", 50 },
                {"Muffin", 40 },
                {"Baguette", 30 },
                {"Bagel", 20 },
            };

            Dictionary<string, int> bakeds = new Dictionary<string, int>();

            Queue<double> waters = new Queue<double>(Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray());
            Stack<double> flours = new Stack<double>(Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray());

            while (waters.Count != 0 && flours.Count != 0)
            {
                double ratio = waters.Peek() + flours.Peek();
                double currentWater = (waters.Peek() * 100) / ratio;

                if (products.ContainsValue(currentWater))
                {
                    foreach (var product in products)
                    {
                        string productName = product.Key;
                        if (product.Value == currentWater)
                        {
                            if (!bakeds.ContainsKey(product.Key))
                            {
                                bakeds.Add(productName, 1);
                                waters.Dequeue();
                                flours.Pop();
                                break;
                            }
                            else
                            {
                                bakeds[productName]++;
                                waters.Dequeue();
                                flours.Pop();
                                break;
                            }
                        }
                    }
                }
                else
                {
                    double currWater = waters.Dequeue();
                    double currFlour = flours.Pop();
                    double sum = currFlour - currWater;

                    if (!bakeds.ContainsKey("Croissant"))
                    {
                        bakeds.Add("Croissant", 1);
                    }
                    else
                    {
                        bakeds["Croissant"]++;
                    }

                    flours.Push(sum);
                }
            }
        }
    }
}
