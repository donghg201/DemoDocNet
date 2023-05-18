using Demo.Dto;
using Demo.Models;
using Demo.Repositories.IRepositories;

namespace Demo.Uow.IUow
{
    public interface ITaskUow
    {
        ITaskRepository<CustomerTaskDto> TaskRepository { get; }

        void SaveChanges();
    }
}
