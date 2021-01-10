using System;
using System.Reflection.Metadata.Ecma335;
using basketball_teams.client;
using basketball_teams.domain;
using basketball_teams.repos;
using basketball_teams.repos.file;

namespace basketball_teams
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository<Team> teamsRepository = new TeamsFileRepository("Teams.csv");
            teamsRepository.FindAll().ForEach(team => Console.WriteLine(team.Name)); 
            Client client = new ConsoleClient();
            
            client.Run();
        }
    }
}