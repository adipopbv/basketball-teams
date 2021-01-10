using basketball_teams.domain;
using basketball_teams.repos.memory;

namespace basketball_teams.repos.file
{
    public abstract class FileRepository<TEntity>: MemoryRepository<TEntity> where TEntity: Entity
    {
        protected readonly string DataFilesPath = @"../../../resources/dataFiles/";
        protected readonly string FileName;
        protected readonly char Separator = ',';

        public FileRepository(string fileName)
        {
            this.FileName = fileName;
            LoadData();
        }
        
        protected abstract void LoadData();
    }
}