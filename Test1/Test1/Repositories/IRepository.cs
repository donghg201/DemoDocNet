using System.Collections.Generic;

namespace RepositoryPatternDemo.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> FetchAll();
        TEntity FindById(int id);
        TEntity Add(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity, int id);
    }
}
