using System.Collections.Generic;

namespace basketball_teams.Repos
{
    public interface IRepository<TId, TEntity>
    {
        public TEntity FindOne(TId id);
        
        public List<TEntity> FindAll();
        
        public TEntity Add(TEntity entity);
        
        public TEntity Modify(TId id, TEntity newEntity);
        
        public TEntity Remove(TId id);
    }
}