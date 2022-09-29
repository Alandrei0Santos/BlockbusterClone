using BlockbusterClone.Models;
using BlockbusterClone.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlockbusterClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IBlockbusterServices blockbusterService;

        public MoviesController(IBlockbusterServices blockbusterService)
        {
            this.blockbusterService = blockbusterService;
        }

        // GET: api/<MoviesController>
        [HttpGet]
        public ActionResult<List<Movies>> Get()
        {
            return blockbusterService.GetMovies();
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public ActionResult<Movies> Get(string id)
        {
            var movie = blockbusterService.GetDetails(id);

            if (movie == null)
            {
                return NotFound($"Movie with id = {id} not found");
            }

            return movie;
        }

        // POST api/<MoviesController>
        [HttpPost]
        public ActionResult<Movies> Post([FromBody] Movies movies)
        {
            blockbusterService.Create(movies);

            return CreatedAtAction(nameof(Get), new { id = movies.Id }, movies);
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Movies movies)
        {
            var existingMovie = blockbusterService.GetDetails(id);

            if(existingMovie == null)
            {
                return NotFound($"Movie with id = {id} not found");
            }

            blockbusterService.Update(id, movies);

            return NoContent();
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var movies = blockbusterService.GetDetails(id);

            if (movies == null)
            {
                return NotFound($"Movie with id = {id} not found");
            }

            blockbusterService.Remove(movies.Id);

            return Ok("$Movie with id = {id} removed");
        }
    }
}
