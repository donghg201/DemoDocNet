using Demo.Models;
using Demo.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Repositories
{
    public class BranchRepository : IRepositoryInt<Branch>
    {
        private readonly MyDbContext _context;

        public BranchRepository(MyDbContext context)
        {
            this._context = context;
        }

        public Branch Add(Branch entity)
        {
            this._context.Branchs.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var branch = (from b in _context.Branchs
                          where b.BranchId == id
                          select b).FirstOrDefault();
            this._context.Branchs.Remove(branch);
        }

        public List<Branch> FetchAll()
        {
            var branch = (from b in _context.Branchs
                          select b).ToList();
            return branch;
        }

        public Branch FindById(int id)
        {
            var branch = (from b in _context.Branchs
                         where b.BranchId == id
                         select b).FirstOrDefault();
            return branch;
        }

        public void Update(Branch entity, int id)
        {
            var branch = (from b in _context.Branchs
                          where b.BranchId == id
                          select b).FirstOrDefault();
            branch.Address = entity.Address;
            branch.City = entity.City;
            branch.Name = entity.Name;
            branch.State = entity.State;
            branch.ZipCode = entity.ZipCode;
        }
    }
}
