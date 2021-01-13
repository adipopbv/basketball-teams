using System.Collections.Generic;
using System.Linq;
using basketball_teams.domain;
using basketball_teams.domain.exceptions;

namespace basketball_teams.repos.memory
{
    public class MemoryRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected Dictionary<Id, TEntity> Entities;

        public MemoryRepository()
        {
            Entities = new Dictionary<Id, TEntity>();
        }

        public MemoryRepository(List<TEntity> entities)
        {
            Entities = new Dictionary<Id, TEntity>();
            entities.ForEach(entity => Entities.Add(entity.Id, entity));
        }
        
        public TEntity FindOne(Id id)
        {
            foreach (var (key, value) in Entities)
            {
                if (key.Value == id.Value)
                    return value;
            }

            return null;
        }

        public List<TEntity> FindAll()
        {
            return Entities.Values.ToList();
        }

        public virtual TEntity Add(TEntity entity)
        {
            while (Entities.ContainsKey(entity.Id))
            {
                Id id = new Id(true);
                entity.Id = id;
            } 
            Entities.Add(entity.Id, entity);

            return entity;
        }

        public virtual TEntity Modify(Id id, TEntity newTEntity)
        {
            TEntity oldTEntity = Entities[id];
            if (oldTEntity == null)
                throw new NotFoundException();

            newTEntity.Id = id;
            Entities.Remove(id);
            Entities.Add(id, newTEntity);

            return oldTEntity;
        }

        public virtual TEntity Remove(Id id)
        {
            TEntity entity = Entities[id];
            if (entity == null)
                throw new NotFoundException();

            Entities.Remove(id);

            return entity;
        }
    }
}