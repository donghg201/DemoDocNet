using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Movie> FetchAll()
        {
            var movies = this._context.Movies.ToList();

            //IEnumerable<Movie> movies = this._context.Movies.FromSql($"select * from dbo.Movies").ToList();

            //IEnumerable<Movie> movies = (from m in _context.Movies
            //select m).ToList();


            return movies;
        }

        public Movie FindById(int id)
        {
            // Method syntax
            var movie = this._context.Movies.Where(m => m.MovieId == id).FirstOrDefault();


            // SQL query syntax
            var movie1 = this._context.Movies.
            FromSql($"Select * from dbo.Movies m where m.MovieId = {id}").FirstOrDefault();

            // Linq query syntax
            var movie2 = (from m in _context.Movies
                         where m.MovieId == id
                         select m).FirstOrDefault();

            return movie;
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
            movie.Note = entity.Note;
        }
    }
}
