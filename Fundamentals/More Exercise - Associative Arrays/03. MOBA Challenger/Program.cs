using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> playerStats = new Dictionary<string, Dictionary<string, int>>();
            string player = string.Empty;
            string position = string.Empty;
            int skill = 0;


            while (true)
            {
                List<string> input = Console.ReadLine().Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (input[0] == "Season")
                {
                    break;
                }

                if (!(input.Contains("vs")))
                {
                    player = input[0];
                    position = input[1];
                    skill = int.Parse(input[2]);

                    if (playerStats.ContainsKey(player))
                    {
                        if (playerStats[player].ContainsKey(position))
                        {
                            if (playerStats[player][position] < skill)
                            {
                                playerStats[player][position] = skill;
                            }
                        }
                        else
                        {
                            playerStats[player][position] = skill;
                        }
                    }
                    else
                    {
                        Dictionary<string, int> asistDictionary = new Dictionary<string, int>();
                        asistDictionary.Add(position, skill);
                        playerStats[player] = asistDictionary;
                    }
                }
                else
                {
                    string firstPlayer = input[0];
                    string secondPlayer = input[2];

                    if (playerStats.ContainsKey(firstPlayer) && playerStats.ContainsKey(secondPlayer))
                    {
                        string playerToRemove = string.Empty;

                        foreach (var role in playerStats[firstPlayer])
                        {
                            foreach (var pos in playerStats[secondPlayer])
                            {
                                if (role.Key == pos.Key)
                                {
                                    if (playerStats[firstPlayer].Values.Sum() > playerStats[secondPlayer].Values.Sum())
                                    {
                                        playerToRemove = secondPlayer;
                                    }
                                    else if (playerStats[firstPlayer].Values.Sum() < playerStats[secondPlayer].Values.Sum())
                                    {

                                        playerToRemove = firstPlayer;
                                    }
                                }
                            }
                        }
                        playerStats.Remove(playerToRemove);
                    }
                }
            }

            foreach (var pl in playerStats.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{pl.Key}: {pl.Value.Values.Sum()} skill");

                foreach (var kvp in pl.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {kvp.Key} <::> {kvp.Value}");
                }
            }
        }
    }
}
