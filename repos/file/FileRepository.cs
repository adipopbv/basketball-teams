using basketball_teams.domain;
using basketball_teams.repos.memory;

namespace basketball_teams.repos.file
{
    public abstract class FileRepository<TEntity> : MemoryRepository<TEntity> where TEntity : Entity
    {
        protected readonly string DataFilesPath = @"../../../resources/dataFiles/";
        protected readonly string FileName;
        protected readonly char Separator = ',';

        public FileRepository(string fileName)
        {
            this.FileName = fileName;
        }
        
        protected abstract void LoadData();
        
        protected abstract void SaveData();
        
        public override TEntity Add(TEntity entity)
        {
            TEntity addedEntity = base.Add(entity);
            SaveData();
            return addedEntity;
        }

        public override TEntity Modify(Id id, TEntity newTEntity)
        {
            TEntity modifiedEntity = base.Modify(id, newTEntity);
            SaveData();
            return modifiedEntity;
        }

        public override TEntity Remove(Id id)
        {
            TEntity deletedEntity = base.Remove(id);
            SaveData();
            return deletedEntity;
        }
    }
}