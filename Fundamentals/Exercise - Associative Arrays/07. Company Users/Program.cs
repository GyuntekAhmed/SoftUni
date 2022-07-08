using System;
using System.Collections.Generic;

namespace _07._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            while (true)
            {
                string comand = Console.ReadLine();
                if (comand == "End")
                {
                    break;
                }

                string[] tokens = comand.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string companyName = tokens[0];
                string employeeId = tokens[1];

                if (!companies.ContainsKey(companyName))
                {
                    companies[companyName] = new List<string>();
                }
                if (companies[companyName].Contains(employeeId))
                {
                    continue;
                }
                companies[companyName].Add(employeeId);
            }

            foreach (var company in companies)
            {
                Console.WriteLine(company.Key);

                foreach (var employeeId in company.Value)
                {
                    Console.WriteLine($"-- {employeeId}");
                }
            }
        }
    }
}
