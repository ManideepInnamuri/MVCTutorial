using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyAPI.DTOs;
using VidlyAPI.Models;

namespace VidlyAPI.Controllers
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDTO>));
        }

        // Get /api/Movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(p => p.Id == id);
            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        //Post / api/Movies
        [HttpPost]
        public IHttpActionResult AddMovie(MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDTO, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //Put /api/Movies
        [HttpPut]
        public void UpdateMovie(int id, MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieinDb = _context.Movies.SingleOrDefault(p => p.Id == id);
            if (movieinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(movieDto, movieinDb);
            _context.SaveChanges();
        }

        [HttpDelete]
        public IHttpActionResult Deletemovie(int id)
        {
            var movieInDB = _context.Movies.SingleOrDefault(p => p.Id == id);
            if (movieInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movieInDB);
            _context.SaveChanges();
            return Ok(HttpStatusCode.NoContent);
        }
    }
}
