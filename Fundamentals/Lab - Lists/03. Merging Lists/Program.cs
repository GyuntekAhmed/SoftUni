﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> resultList = new List<int>();

            int isBiggerList = Math.Max(firstList.Count, secondList.Count);

            for (int i = 0; i < isBiggerList; i++)
            {
                if (firstList.Count > i)
                {
                    resultList.Add(firstList[i]);
                }
                if (secondList.Count > i)
                {
                    resultList.Add(secondList[i]);
                }
            }
            Console.WriteLine(string.Join(" ",resultList));

        }
    }
}
