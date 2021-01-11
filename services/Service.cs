using System;
using System.Collections.Generic;
using System.Linq;
using basketball_teams.domain;
using basketball_teams.repos;

namespace basketball_teams.services
{
    public class Service
    {
        protected IRepository<Team> TeamsRepository;
        protected IRepository<Player> PlayersRepository;
        protected IRepository<Game> GamesRepository;
        protected IRepository<ActivePlayer> ActivePlayersRepository;
        
        public Service(IRepository<Team> teamsRepository, IRepository<Player> playersRepository, IRepository<Game> gamesRepository, IRepository<ActivePlayer> activePlayersRepository)
        {
            TeamsRepository = teamsRepository;
            PlayersRepository = playersRepository;
            GamesRepository = gamesRepository;
            ActivePlayersRepository = activePlayersRepository;
        }

        public List<Player> GetPlayersOfTeam(Id teamId)
        {
            return PlayersRepository.FindAll().Where(player => player.Team.Id.Value == teamId.Value).ToList();
        }

        public List<ActivePlayer> GetActivePlayersOfTeamFromGame(Id teamId, Id gameId)
        {
            return ActivePlayersRepository.FindAll().Where(activePlayer => activePlayer.Player.Team.Id.Value == teamId.Value && activePlayer.Game.Id.Value == gameId.Value).ToList();
        }

        public List<Game> GetGamesFromTimePeriod(string periodStart, string periodEnd)
        {
            DateTime start = DateTime.Parse(periodStart);
            DateTime end = DateTime.Parse(periodEnd);
            return GamesRepository.FindAll().Where(game => game.Date > start && game.Date < end).ToList();
        }
    }
}