using Demo.Dto;
using System.Collections.Generic;

namespace Demo.Repositories.IRepositories
{
    public interface ITaskRepository<T> where T : class
    {
        T GetCustomerById(int id);
    }
}
