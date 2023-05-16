using Demo.Models;
using Demo.Repositories.IRepositories;

namespace Demo.Uow.IUow
{
    public interface IBranchUow
    {
        IRepositoryInt<Branch> BranchRepository { get; }

        void SaveChanges();
    }
}
