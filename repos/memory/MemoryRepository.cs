using System.Collections.Generic;
using System.Linq;
using basketball_teams.domain;
using basketball_teams.domain.exceptions;

namespace basketball_teams.repos.memory
{
    public class MemoryRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private Dictionary<Id, TEntity> _entities;

        public MemoryRepository()
        {
            _entities = new Dictionary<Id, TEntity>();
        }

        public MemoryRepository(List<TEntity> entities)
        {
            _entities = new Dictionary<Id, TEntity>();
            entities.ForEach(entity => _entities.Add(entity.Id, entity));
        }
        
        public TEntity FindOne(Id id)
        {
            foreach (var (key, value) in _entities)
            {
                if (key.Value == id.Value)
                    return value;
            }

            return null;
        }

        public List<TEntity> FindAll()
        {
            return _entities.Values.ToList();
        }

        public TEntity Add(TEntity entity)
        {
            while (_entities.ContainsKey(entity.Id))
            {
                Id id = new Id(true);
                entity.Id = id;
            } 
            _entities.Add(entity.Id, entity);

            return entity;
        }

        public TEntity Modify(Id id, TEntity newTEntity)
        {
            TEntity oldTEntity = _entities[id];
            if (oldTEntity == null)
                throw new NotFoundException();

            newTEntity.Id = id;
            _entities.Remove(id);
            _entities.Add(id, newTEntity);

            return oldTEntity;
        }

        public TEntity Remove(Id id)
        {
            TEntity entity = _entities[id];
            if (entity == null)
                throw new NotFoundException();

            _entities.Remove(id);

            return entity;
        }
    }
}