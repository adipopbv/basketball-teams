using System.Collections.Generic;
using basketball_teams.domain;

namespace basketball_teams.repos
{
    public interface IRepository<TEntity>
    {
        public TEntity FindOne(Id id);
        
        public List<TEntity> FindAll();
        
        public TEntity Add(TEntity entity);
        
        public TEntity Modify(Id id, TEntity newEntity);
        
        public TEntity Remove(Id id);
    }
}