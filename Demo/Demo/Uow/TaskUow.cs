using Demo.Dto;
using Demo.Models;
using Demo.Repositories;
using Demo.Repositories.IRepositories;
using Demo.Uow.IUow;

namespace Demo.Uow
{
    public class TaskUow : ITaskUow
    {

        private readonly MyDbContext _context;

        public TaskUow(MyDbContext context)
        {
            this._context = context;
        }

        private ITaskRepository<CustomerTaskDto> taskRepository;
        public ITaskRepository<CustomerTaskDto> TaskRepository
        {
            get
            {
                if(taskRepository == null)
                {
                    taskRepository = new TaskRepository(_context);
                }
                return taskRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
