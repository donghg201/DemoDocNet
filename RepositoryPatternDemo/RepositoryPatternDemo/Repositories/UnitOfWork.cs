using RepositoryPatternDemo.Data;

namespace RepositoryPatternDemo.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private SchoolDbContext context;

        public UnitOfWork(SchoolDbContext context)
        {
            this.context = context;
        }

        private IRepository<Student> studentRepository;
        public IRepository<Student> StudentRepository
        {
            get
            {
                if (studentRepository == null)
                {
                    studentRepository = new StudentRepository (context);
                }

                return studentRepository;
            }
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
