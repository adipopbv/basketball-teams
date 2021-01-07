using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using basketball_teams.domain;
using basketball_teams.domain.Exceptions;

namespace basketball_teams.Repos.Memory
{
    public class MemoryRepository: IRepository<Id, Entity>
    {
        private Dictionary<Id, Entity> _entities;

        public MemoryRepository()
        {
        }

        public MemoryRepository(List<Entity> entities)
        {
            _entities = new Dictionary<Id, Entity>();
            entities.ForEach(entity => _entities.Add(entity.Id, entity));
        }
        
        public Entity FindOne(Id id)
        {
            return _entities[id];
        }

        public List<Entity> FindAll()
        {
            return _entities.Values.ToList();
        }

        public Entity Add(Entity entity)
        {
            while (_entities[entity.Id] != null)
            {
                Id id = new Id(true);
                entity.Id = id;
            } 
            _entities.Add(entity.Id, entity);

            return entity;
        }

        public Entity Modify(Id id, Entity newEntity)
        {
            Entity oldEntity = _entities[id];
            if (oldEntity == null)
                throw new NotFoundException();

            newEntity.Id = id;
            _entities.Remove(id);
            _entities.Add(id, newEntity);

            return oldEntity;
        }

        public Entity Remove(Id id)
        {
            Entity entity = _entities[id];
            if (entity == null)
                throw new NotFoundException();

            _entities.Remove(id);

            return entity;
        }
    }
}