using QuanLyPhim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyPhim.Repositories
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly MyDbContext _context;

        public MovieRepository(MyDbContext context)
        {
            this._context = context;
        }

        public Movie Add(Movie entity)
        {
            this._context.Movies.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var movie = this._context.Movies.FirstOrDefault(stu => stu.MovieId == id);
            this._context.Movies.Remove(movie);
        }

        public List<Movie> FetchAll()
        {
            return this._context.Movies.ToList();
        }

        public Movie FindById(int id)
        {
            return this._context.Movies.FirstOrDefault(mov => mov.MovieId == id);
        }

        public void Update(Movie entity, int id)
        {
            var movie = this._context.Movies.FirstOrDefault(mov => mov.MovieId == id);
            movie.MovieName = entity.MovieName;
            movie.StartDate = entity.StartDate;
            movie.EndDate = entity.EndDate;
            movie.Actor = entity.Actor;
            movie.Director = entity.Director;
            movie.MovieStudio = entity.MovieStudio;
            movie.PosterMovie = entity.PosterMovie;
        }
    }
}
