using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _movieContext;
        public MoviesController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie(Movie movie)
        {
            if (_movieContext == null)
            {
                return NotFound();
            }

            _movieContext.MoviesList.Add(movie);

            await _movieContext.SaveChangesAsync();

            return movie;
        }

        //GET : api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            if (_movieContext == null)
            {
                return NotFound();
            }
            return await _movieContext.MoviesList.ToListAsync();
        }

        //GET : api/movies/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovies(Guid id)
        {
            if (_movieContext == null)
            {
                return NotFound();
            }

            var movie = await _movieContext.MoviesList.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Movie>> UpdateMovie(Guid id, Movie movie)
        {
            if (movie.Id != id)
            {
                return BadRequest();
            }

            _movieContext.Entry(movie).State = EntityState.Modified;

            await _movieContext.SaveChangesAsync();

            var updatedMovie = _movieContext.MoviesList.FirstOrDefaultAsync(x => x.Id == id);

            return movie;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            var movie = await _movieContext.MoviesList.FindAsync(id);

            if (movie == null) return NotFound();

            _movieContext.MoviesList.Remove(movie);

            await _movieContext.SaveChangesAsync();

            return NoContent();

        }
    }
}
