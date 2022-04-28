using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Team> playersAndTeams = new Dictionary<string, Team>();

            string inputData = Console.ReadLine(); 


            while (inputData != "END")
            {
                string[] tokens = inputData.Split(";", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                try
                {
                    if (command == "Team")
                    {
                        string teamName = tokens[1];

                        var team = new Team(teamName);
                        playersAndTeams.Add(teamName, team);
                    }
                    else if (command == "Add")
                    {
                        string teamName = tokens[1];

                        if (playersAndTeams.ContainsKey(teamName) == false)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            inputData = Console.ReadLine();
                            continue;
                        }

                        string playerName = tokens[2];
                        int endurance = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);

                        var team = playersAndTeams[teamName];

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        team.AddPlayer(player);

                    }
                    else if (command == "Remove")
                    {
                        string teamName = tokens[1];
                        string playerName = tokens[2];

                        var team = playersAndTeams[teamName];
                        team.RemovePlayer(playerName);
                    }
                    else if (command == "Rating")
                    {
                        string teamName = tokens[1];

                        if (playersAndTeams.ContainsKey(teamName) == false)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            inputData = Console.ReadLine();
                            continue;
                        }
                        var team = playersAndTeams[teamName];

                        Console.WriteLine($"{teamName} - {team.AverageRating}");

                    }

                }
                catch (Exception ex)
                     when (ex is ArgumentException || ex is InvalidOperationException)
                {
                    Console.WriteLine(ex.Message);
                }
                inputData = Console.ReadLine();
            }
        }
    }
}


