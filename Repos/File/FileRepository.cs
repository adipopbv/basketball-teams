using System.Collections.Generic;
using System.Net;
using basketball_teams.domain;
using basketball_teams.Repos.Memory;

namespace basketball_teams.Repos.File
{
    public class FileRepository: MemoryRepository
    {
        private string _dataFilesPath = @".\Resources\DataFiles\";
        private string _fileName;

        public FileRepository(string fileName)
        {
            _fileName = fileName;
            LoadData();
        }

        protected void LoadData()
        {
            string path = _dataFilesPath + "Students.csv";
            string[] lines = System.IO.File.ReadAllLines(@path);

            foreach (string line in lines)
            {
                
            }
        }
    }
}