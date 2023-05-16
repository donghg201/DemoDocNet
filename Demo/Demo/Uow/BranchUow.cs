using Demo.Models;
using Demo.Repositories;
using Demo.Repositories.IRepositories;
using Demo.Uow.IUow;

namespace Demo.Uow
{
    public class BranchUow : IBranchUow
    {
        private readonly MyDbContext _context;

        public BranchUow(MyDbContext context)
        {
            this._context = context;
        }

        private IRepository<Branch> branchRepository;
        public IRepository<Branch> BranchRepository
        {
            get
            {
                if (branchRepository == null)
                {
                    branchRepository = new BranchRepository(_context);
                }
                return branchRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
