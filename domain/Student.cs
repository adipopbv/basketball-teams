namespace basketball_teams.domain
{
    public class Student : Entity
    {
        public string Name { get; set; }
        public string School { get; set; }
        
        public Student(Id id, string name, string school) : base(id)
        {
            Name = name;
            School = school;
        }
    }
}