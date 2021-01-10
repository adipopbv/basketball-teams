using System;
using System.Collections.Generic;
using basketball_teams.domain;
using basketball_teams.domain.exceptions;
using basketball_teams.services;

namespace basketball_teams.client
{
    public class ConsoleClient : Client
    {
        public ConsoleClient(Service service) : base(service)
        {
        }

        public override void Run()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\nBASKETBALL TEAMS");
                    Console.WriteLine("[0]: Exit" +
                                      "\n[1]: Get all players of team");
                    Console.WriteLine("\n> ");
                    string command = Console.ReadLine();
                    switch (command)
                    {
                        case "0":
                            Console.WriteLine("Exiting app...");
                            return;
                        case "1": GetPlayersOfTeam();
                            break;
                        default: Console.WriteLine("\nCommand not found");
                            break;
                    }
                }
                catch (AppException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }

        private void GetPlayersOfTeam()
        {
            Console.Write("\nTeam id: ");
            string teamId = Console.ReadLine();
            List<Player> players = Service.GetPlayersOfTeam(new Id(int.Parse(teamId!)));
            
            Console.Write("Players of team " + players[0].Team.Name + ": \n");
            players.ForEach(player => Console.WriteLine(player.Id.Value + " | " + player.Name + " | " + player.Team.Name));
        }
    }
}