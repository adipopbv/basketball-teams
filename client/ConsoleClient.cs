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
                                      "\n[1]: Get all players of team" +
                                      "\n[2]: Get all active players of team from game");
                    Console.WriteLine("\n> ");
                    string command = Console.ReadLine();
                    switch (command)
                    {
                        case "0":
                            Console.WriteLine("Exiting app...");
                            return;
                        case "1": GetPlayersOfTeam();
                            break;
                        case "2": GetActivePlayersOfTeamFromGame();
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
            players.ForEach(player => Console.WriteLine(player.Id.Value + " | " + player.Name));
        }

        private void GetActivePlayersOfTeamFromGame()
        {
            Console.Write("\nTeam id: ");
            string teamId = Console.ReadLine();
            Console.Write("\nGame id: ");
            string gameId = Console.ReadLine();
            List<ActivePlayer> activePlayers = Service.GetActivePlayersOfTeamFromGame(new Id(int.Parse(teamId!)), new Id(int.Parse(gameId!)));
            
            Console.Write("Active players of team " + activePlayers[0].Player.Team.Name + " taking part in the " + activePlayers[0].Game.Id.Value + " game: \n");
            activePlayers.ForEach(activePlayer => Console.WriteLine(activePlayer.Player.Id.Value + " | " + activePlayer.Player.Name + " | " + activePlayer.ScoredPoints + " | " + ActivePlayer.StatusToString(activePlayer.Status)));
        }
    }
}