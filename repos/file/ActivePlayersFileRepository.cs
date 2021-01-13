using System;
using System.Collections.Generic;
using basketball_teams.domain;

namespace basketball_teams.repos.file
{
    public class ActivePlayersFileRepository : FileRepository<ActivePlayer>
    {
        private IRepository<Player> _playersRepository;
        private IRepository<Game> _gamesRepository;
    
        public ActivePlayersFileRepository(string fileName, IRepository<Player> playersRepository, IRepository<Game> gamesRepository) : base(fileName)
        {
            Console.WriteLine("ceva");
            _playersRepository = playersRepository;
            _gamesRepository = gamesRepository;
            LoadData();
        }
    
        protected override void LoadData()
        {
            string path = DataFilesPath + FileName;
            string[] lines = System.IO.File.ReadAllLines(@path);
    
            foreach (string line in lines)
            {
                string[] fields = line.Split(Separator);

                ActivePlayer activePlayer = new ActivePlayer(new Id(int.Parse(fields[0])),
                    _playersRepository.FindOne(new Id(int.Parse(fields[1]))),
                    _gamesRepository.FindOne(new Id(int.Parse(fields[2]))),
                    int.Parse(fields[3]),
                    ActivePlayer.StringToStatus(fields[4]));
                base.Add(activePlayer);
            }
        }
        
        protected override void SaveData()
        {
            string path = DataFilesPath + FileName;
            List<string> lines = new List<string>();

            foreach (var activePlayer in FindAll())
            {
                lines.Add(activePlayer.Id.Value + "," + activePlayer.Player.Id.Value + "," +
                          activePlayer.Game.Id.Value + "," + activePlayer.ScoredPoints + "," +
                          ActivePlayer.StatusToString(activePlayer.Status));
            }
            System.IO.File.WriteAllLines(@path, lines);
        }
    }
}