namespace basketball_teams.domain
{
    public class Player : Student
    {
        public Team Team { get; set; }
        
        public Player(Id id, string name, string school, Team team) : base(id, name, school)
        {
            Team = team;
        }
    }
}