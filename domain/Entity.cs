namespace basketball_teams.domain
{
    public class Entity
    {
        public Id Id { get; set; }

        public Entity(Id id)
        {
            Id = id;
        }
    }
}