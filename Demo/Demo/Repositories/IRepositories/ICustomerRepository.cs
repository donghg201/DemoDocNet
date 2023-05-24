using System.Collections.Generic;

namespace Demo.Repositories.IRepositories
{
    public interface ICustomerRepository<T> where T : class
    {
        List<T> FetchAll();
        T FindById(int id);
        T Add(T entity);
        void Update(T entity, int id);
        void Delete(int id);
        List<T> GetInfoCustomerBussiness(string name);
        List<T> GetInfoCustomerIndividual(string name);

        List<T> GetAccTransaction(int id);


       
    }
}
