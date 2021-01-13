using System.Collections.Generic;

namespace Mock.RestApi.IServices
{
    public interface IEntityService<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        bool IsExist(int id);
    }
}
