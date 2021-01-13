using Mock.RestApi.IServices;
using Mock.RestApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mock.RestApi.Services
{
    public class EntityService<TEntity> : IEntityService<TEntity>
        where TEntity : Base
    {
        protected readonly ICollection<TEntity> entities;

        public EntityService(ICollection<TEntity> entities)
        {
            this.entities = entities;
        }

        public void Add(TEntity entity)
        {
            int lastId = entities.Max(m => m.Id);
            entity.Id = ++lastId;

            entities.Add(entity);
        }

        public IEnumerable<TEntity> Get()
        {
            return entities;
        }

        public TEntity Get(int id)
        {
            return entities.SingleOrDefault(e => e.Id == id);
        }

        public bool IsExist(int id)
        {
            return entities.Any(m => m.Id == id);
        }

        public void Delete(int id)
        {
            entities.Remove(Get(id));
        }

        public void Update(TEntity entity)
        {
            Delete(entity.Id);
            entities.Add(entity);
        }
    }
}
