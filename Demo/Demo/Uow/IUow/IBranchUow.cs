using Demo.Models;
using Demo.Repositories.IRepositories;

namespace Demo.Uow.IUow
{
    public interface IBranchUow
    {
        IRepository<Branch> BranchRepository { get; }

        void SaveChanges();
    }
}
