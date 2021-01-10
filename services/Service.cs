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
        
        public Service(IRepository<Team> teamsRepository, IRepository<Player> playersRepository)
        {
            TeamsRepository = teamsRepository;
            PlayersRepository = playersRepository;
        }

        public List<Player> GetPlayersOfTeam(Id teamId)
        {
            return PlayersRepository.FindAll().Where(player => player.Team.Id.Value == teamId.Value).ToList();
        }
    }
}