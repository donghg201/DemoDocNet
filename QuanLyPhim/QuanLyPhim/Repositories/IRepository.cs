using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyPhim.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> FetchAll();
        T FindById(int id);
        T Add(T entity);
        void Update(T entity, int id);
        void Delete(int id);
    }
}
