using System.Collections.Generic;

namespace Demo.Repositories.IRepositories
{
    public interface IBussinessRepository<T> where T : class
    {
        List<T> FetchAll();
        T FindById(string id);
        T Add(T entity);
        void Update(T entity, string id);
        void Delete(string id);
        T GetBussinessByStateId(string id);
    }
}
