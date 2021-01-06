namespace basketball_teams.domain
{
    public class Team: Entity
    {
        public string Name { get; set; }
        
        public Team(Id id, string name) : base(id)
        {
            Name = name;
        }
    }
}