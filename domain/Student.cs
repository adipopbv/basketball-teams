using System.Data.Common;

namespace basketball_teams.domain
{
    public class Student: Entity
    {
        public Id Id { get; set; }
        public string Name { get; set; }
        public School School { get; set; }
        
        public Student(Id id, string name, School school) : base(id)
        {
            Name = name;
            School = school;
        }
    }
}