using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyPhim.Models;
using QuanLyPhim.Services;

namespace QuanLyPhim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IEnumerable<Movie> GetAll()
        {
            return this._movieService.GetAllMovie();
        }

        [HttpGet("{id}")]
        public Movie GetMovie(int id)
        {
            return this._movieService.GetMovieById(id);
        }

        [HttpPost]
        public void Add([FromBody]Movie movie)
        {
            this._movieService.AddMovie(movie);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Movie movie)
        {
            this._movieService.UpdateMovie(movie, id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._movieService.RemoveMovie(id);
        }
    }
}