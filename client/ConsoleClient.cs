using System;
using System.Collections.Generic;
using System.Threading.Channels;
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
                                      "\n[2]: Get all active players of team from game" +
                                      "\n[3]: Get all games from time period (dd/MM/yyyy)" +
                                      "\n[4]: Get score from game");
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
                        case "3": GetGamesFromTimePeriod();
                            break;
                        case "4": GetScoreFromGame();
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

            if (players.Count > 0)
            {
                Console.Write("Players of team " + players[0].Team.Name + ": \n");
                players.ForEach(player => Console.WriteLine(player.Id.Value + " | " + player.Name));
            }
            else
                Console.WriteLine("No player in that team!");
        }

        private void GetActivePlayersOfTeamFromGame()
        {
            Console.Write("\nTeam id: ");
            string teamId = Console.ReadLine();
            Console.Write("\nGame id: ");
            string gameId = Console.ReadLine();
            List<ActivePlayer> activePlayers = Service.GetActivePlayersOfTeamFromGame(new Id(int.Parse(teamId!)), new Id(int.Parse(gameId!)));

            if (activePlayers.Count > 0)
            {
                Console.Write("Active players of team " + activePlayers[0].Player.Team.Name + " taking part in the " +
                              activePlayers[0].Game.Id.Value + " game: \n");
                activePlayers.ForEach(activePlayer => Console.WriteLine(activePlayer.Player.Id.Value + " | " +
                                                                        activePlayer.Player.Name + " | " +
                                                                        activePlayer.ScoredPoints + " | " +
                                                                        ActivePlayer.StatusToString(activePlayer
                                                                            .Status)));
            }
            else
                Console.WriteLine("No active player from that team at that game!");
        }

        private void GetGamesFromTimePeriod()
        {
            Console.Write("\nPeriod start: ");
            string periodStart = Console.ReadLine();
            Console.Write("\nPeriod end: ");
            string periodEnd = Console.ReadLine();
            List<Game> games = Service.GetGamesFromTimePeriod(periodStart, periodEnd);
            
            Console.Write("Games from the given time period: \n");
            games.ForEach(game => Console.WriteLine(game.Id.Value + " | " + game.FirstTeam.Name + " VS " + game.SecondTeam.Name));
        }

        private void GetScoreFromGame()
        {
            Console.Write("\nGame id: ");
            string gameId = Console.ReadLine();
            int score = Service.GetScoreFromGame(new Id(int.Parse(gameId!)));
            
            Console.Write("Score from the " + gameId + " game: " + score);
        }
    }
}