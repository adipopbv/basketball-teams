using System;
using System.Collections.Generic;
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
                base.Add(game);
            }
        }
        
        protected override void SaveData()
        {
            string path = DataFilesPath + FileName;
            List<string> lines = new List<string>();

            foreach (var game in FindAll())
            {
                lines.Add(game.Id.Value + "," + game.FirstTeam.Id.Value + "," + game.SecondTeam.Id.Value + "," + game.Date);
            }
            System.IO.File.WriteAllLines(@path, lines);
        }
    }
}