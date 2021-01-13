using System;

namespace basketball_teams.domain
{
    public class Game : Entity
    {
        public Team FirstTeam { get; set; }
        public Team SecondTeam { get; set; }
        public DateTime Date { get; set; }
        
        public Game(Id id, Team firstTeam, Team secondTeam, DateTime date) : base(id)
        {
            FirstTeam = firstTeam;
            SecondTeam = secondTeam;
            Date = date;
        }
    }
}