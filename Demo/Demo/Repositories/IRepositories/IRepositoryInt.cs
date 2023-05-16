using System.Collections.Generic;

namespace Demo.Repositories.IRepositories
{
    public interface IRepositoryInt<T> where T : class
    {
        List<T> FetchAll();
        T FindById(int id);
        T Add(T entity);
        void Update(T entity, int id);
        void Delete(int id);
    }
}
