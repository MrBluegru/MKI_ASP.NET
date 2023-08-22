using MKIMovie.Models;
using MKIMovie.Services;
using Microsoft.AspNetCore.Mvc;

namespace MKIMovie.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    public MovieController() { }

    [HttpGet]
    public ActionResult<List<Movie>> GetAll()
    {
        try
        {
            return MovieService.GetAll();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Movie> Get(int id)
    {
        try
        {
            var movie = MovieService.Get(id);

            if (movie == null)
                return NotFound();

            return movie;
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public IActionResult Create(Movie movie)
    {
        try
        {
            MovieService.Add(movie);
            return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Movie movie)
    {
        try
        {
            if (id != movie.Id)
                return BadRequest();

            var existingMovie = MovieService.Get(id);
            if (existingMovie is null)
                return NotFound();

            MovieService.Update(movie);

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var movie = MovieService.Get(id);

            if (movie is null)
                return NotFound();

            MovieService.Delete(id);

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
