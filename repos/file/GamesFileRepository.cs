using System;
using basketball_teams.domain;

namespace basketball_teams.repos.file
{
    public class GamesFileRepository : FileRepository<Game>
    {
        private IRepository<Team> _teamsRepository;

        public GamesFileRepository(string fileName, IRepository<Team> teamsRepository) : base(fileName)
        {
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

                Game game = new Game(new Id(int.Parse(fields[0])),
                    _teamsRepository.FindOne(new Id(int.Parse(fields[1]))),
                    _teamsRepository.FindOne(new Id(int.Parse(fields[2]))),
                    DateTime.Parse(fields[3]));
                Add(game);
            }
        }
    }
}