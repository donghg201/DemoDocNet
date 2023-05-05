using QuanLyPhim.Models;
using QuanLyPhim.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyPhim.Services
{
    public class MovieService
    {
        private readonly IUnitOfWork _uow;

        public MovieService(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public void AddMovie(Movie movie)
        {
            this._uow.MovieRepository.Add(movie);
            this._uow.SaveChanges();
        }

        public List<Movie> GetAllMovie()
        {
            return this._uow.MovieRepository.FetchAll();
        }

        public Movie GetMovieById(int id)
        {
            return this._uow.MovieRepository.FindById(id);
        }

        public void UpdateMovie(Movie movie, int id)
        {
            this._uow.MovieRepository.Update(movie, id);
            this._uow.SaveChanges();
        }

        public void RemoveMovie(int id)
        {
            this._uow.MovieRepository.Delete(id);
            this._uow.SaveChanges();
        }
    }
}
