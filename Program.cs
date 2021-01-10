using System;
using basketball_teams.client;
using basketball_teams.domain;
using basketball_teams.repos;
using basketball_teams.repos.file;
using basketball_teams.services;

namespace basketball_teams
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository<Team> teamsRepository = new TeamsFileRepository("Teams.csv");
            IRepository<Player> playersRepository = new PlayersFileRepository("Players.csv", teamsRepository);
            Service service = new Service(teamsRepository, playersRepository);
            Client client = new ConsoleClient(service);
            
            client.Run();
        }
    }
}