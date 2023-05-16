using Demo.Dto;
using Demo.Models;
using Demo.Uow.IUow;
using System.Collections.Generic;

namespace Demo.Services
{
    public class BranchService
    {
        private readonly IBranchUow _uow;

        public BranchService(IBranchUow uow)
        {
            this._uow = uow;
        }

        public void AddBranch(BranchDto branch)
        {
            Branch _branch = new()
            {
                Address = branch.Address,
                City = branch.City,
                Name = branch.Name,
                State = branch.State,
                ZipCode = branch.ZipCode
            };
            this._uow.BranchRepository.Add(_branch);
            this._uow.SaveChanges();
        }

        public List<Branch> GetAllBranch()
        {
            return this._uow.BranchRepository.FetchAll();
        }

        public Branch GetBranchById(int id)
        {
            return this._uow.BranchRepository.FindById(id);
        }

        public void UpdateBranch(BranchDto branch, int id)
        {

            Branch _branch = new()
            {
                Address = branch.Address,
                City = branch.City,
                Name = branch.Name,
                State = branch.State,
                ZipCode = branch.ZipCode
            };
            this._uow.BranchRepository.Update(_branch, id);
            this._uow.SaveChanges();
        }

        public void RemoveBranch(int id)
        {
            this._uow.BranchRepository.Delete(id);
            this._uow.SaveChanges();
        }
    }
}
