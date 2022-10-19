using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TilesMaster
{
    internal class Startup
    {
        static void Main()
        {
            Dictionary<string, int> table = new Dictionary<string, int>()
            {
                {"Sink", 40 },
                {"Oven", 50 },
                {"Countertop", 60 },
                {"Wall", 70 },
                {"Floor", 0 },
            };
            Dictionary<string, int> locations = new Dictionary<string, int>();

            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());
            Queue<int> greyTiles = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());
            bool containsTile = false;

            while (whiteTiles.Count != 0 && greyTiles.Count != 0)
            {
                if (whiteTiles.Peek() == greyTiles.Peek())
                {
                    int sumOfTiles = whiteTiles.Peek() + greyTiles.Peek();

                    foreach (var tile in table)
                    {
                        if (sumOfTiles == tile.Value)
                        {
                            containsTile = false;
                            string tileName = tile.Key;

                            if (!locations.ContainsKey(tileName))
                            {
                                locations.Add(tileName, 1);
                                whiteTiles.Pop();
                                greyTiles.Dequeue();
                                break;
                            }
                            else
                            {
                                locations[tileName]++;
                                whiteTiles.Pop();
                                greyTiles.Dequeue();
                                break;
                            }
                        }
                        else
                        {
                            containsTile = true;
                        }
                    }
                    if (containsTile)
                    {
                        if (!locations.ContainsKey("Floor"))
                        {
                            locations.Add("Floor", 1);
                            whiteTiles.Pop();
                            greyTiles.Dequeue();
                        }
                        else
                        {
                            locations["Floor"]++;
                            whiteTiles.Pop();
                            greyTiles.Dequeue();
                        }
                    }
                }
                else
                {
                    int degreesedWhiteTile = whiteTiles.Peek() / 2;
                    whiteTiles.Pop();
                    whiteTiles.Push(degreesedWhiteTile);
                    int changedgreyPoss = greyTiles.Dequeue();
                    greyTiles.Enqueue(changedgreyPoss);
                }
            }
            if (whiteTiles.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }
            if (greyTiles.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }

            foreach (var item in locations.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }
    }
}
