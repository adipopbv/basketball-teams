using System;
using basketball_teams.domain;

namespace basketball_teams.repos.file
{
    public class PlayersFileRepository : FileRepository<Player>
    {
        private IRepository<Team> _teamsRepository;

        public PlayersFileRepository(string fileName, IRepository<Team> teamsRepository) : base(fileName)
        {
            Console.WriteLine("ceva");
            _teamsRepository = teamsRepository;
            LoadData();
        }
    
        protected override void LoadData()
        {
            string path = DataFilesPath + FileName;
            string[] lines = System.IO.File.ReadAllLines(@path);
    
            foreach (string line in lines)
            {
                string[] fields = line.Split(Separator);

                Player player = new Player(new Id(int.Parse(fields[0])), fields[1], fields[2], _teamsRepository.FindOne(new Id(int.Parse(fields[3]))));
                Add(player);
            }
        }
    }
}