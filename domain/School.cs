namespace basketball_teams.domain
{
    public class School: Entity
    {
        public string Name { get; set; }
        
        public School(Id id, string name) : base(id)
        {
            Name = name;
        }
    }
}