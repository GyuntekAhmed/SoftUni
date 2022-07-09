using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfTeams = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < countOfTeams; i++)
            {
                string[] currTeamInfo = Console.ReadLine().Split('-');
                string creator = currTeamInfo[0];
                string teamName = currTeamInfo[1];

                if (teams.Any(team => team.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(team => team.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    var team = new Team();
                    team.Name = teamName;
                    team.Creator = creator;
                    team.Members = new List<string>();
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }

            string line = Console.ReadLine();

            while (line != "end of assignment")
            {
                string[] memberInfo = line.Split(new string[] {"->"}, StringSplitOptions.RemoveEmptyEntries);
                string memberName = memberInfo[0];
                string teamToJoin = memberInfo[1];

                if (teams.Any(team => team.Members.Contains(memberName)) || teams.Any(creator => creator.Creator == memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamToJoin}!");
                }
                else if (!teams.Any(team => team.Name == teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }
                else
                {
                    var currentTeam = teams.Find(team => team.Name == teamToJoin);
                    currentTeam.Members.Add(memberName);
                }

                line = Console.ReadLine();
            }

            var completedTeams = teams.Where(x => x.Members.Count > 0);
            var disbanedTeams = teams.Where(team => team.Members.Count == 0);

            foreach (var team in completedTeams.OrderByDescending(x => x.Members.Count).ThenBy(y => y.Name))
            {
                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- {team.Creator}");

                foreach (var member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");

            if (disbanedTeams != null)
            {
                foreach (var disbanedTeam in disbanedTeams.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"{disbanedTeam.Name}");
                }
            }
        }
    }

    class Team
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members  { get; set; }
    }
}
