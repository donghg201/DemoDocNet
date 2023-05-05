using QuanLyPhim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyPhim.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private MyDbContext context;

        public UnitOfWork(MyDbContext context)
        {
            this.context = context;
        }

        private IRepository<Movie> movieRepository;
        public IRepository<Movie> MovieRepository
        {
            get
            {
                if (movieRepository == null)
                {
                    movieRepository = new MovieRepository(context);
                }
                return movieRepository;
            }
        }

        private IRepository<Category> categoryRepository;
        public IRepository<Category> CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new CategoryRepository(context);
                }
                return categoryRepository;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
