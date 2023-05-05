using RepositoryPatternDemo.Data;

namespace RepositoryPatternDemo.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Student> StudentRepository { get; }

        void SaveChanges();
    }
}
