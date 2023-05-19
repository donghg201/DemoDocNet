using Demo.Dto;
using Demo.Repositories;
using Demo.Uow.IUow;
using System.Collections.Generic;

namespace Demo.Services
{
    public class TaskService
    {
        private readonly ITaskUow _uow;

        public TaskService(ITaskUow uow)
        {
            this._uow = uow;
        }

        public CustomerTaskDto GetListCustomerAccount(int id)
        {
            return this._uow.TaskRepository.GetCustomerById(id);
        }
    }
}
