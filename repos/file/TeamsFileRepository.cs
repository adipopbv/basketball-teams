using System.Collections.Generic;
using basketball_teams.domain;

namespace basketball_teams.repos.file
{
    public class TeamsFileRepository : FileRepository<Team>
    {
        public TeamsFileRepository(string fileName) : base(fileName)
        {
            LoadData();
        }

        protected override void LoadData()
        {
            string path = DataFilesPath + FileName;
            string[] lines = System.IO.File.ReadAllLines(@path);

            foreach (string line in lines)
            {
                string[] fields = line.Split(Separator);
                
                Team team = new Team(new Id(int.Parse(fields[0])), fields[1]);
                base.Add(team);
            }
        }

        protected override void SaveData()
        {
            string path = DataFilesPath + FileName;
            List<string> lines = new List<string>();

            foreach (var team in FindAll())
            {
                lines.Add(team.Id.Value + "," + team.Name);
            }
            System.IO.File.WriteAllLines(@path, lines);
        }
    }
}