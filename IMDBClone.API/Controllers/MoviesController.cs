using IMDBClone.Application.Features;
using IMDBClone.Application.Features.Movies;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace IMDB_Clone_API.Controllers
{
    [Route("api/movies")]
    public class MoviesController : Controller
    {
        public IMediator Mediator { get; }

        public MoviesController(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{movieId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MovieDto))]
        public async Task<IActionResult> GetSingleMovie([FromRoute] string movieId)
        {
            var movie = await Mediator.Send(new GetSingleMovieQuery(movieId));

            return Ok(movie);
        }

        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<MovieDto>))]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await Mediator.Send(new GetMoviesQuery());

            return Ok(movies);
        }

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = (typeof(MovieDto)))]
        public async Task<IActionResult> CreateMovie([FromBody] MovieForm form)
        {
            var movie = await Mediator.Send(new CreateMovieCommand(form));

            return Ok(movie);
        }

        [HttpPut("{movieId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = (typeof(MovieDto)))]
        public async Task<IActionResult> UpdateMovie([FromRoute] string movieId, [FromBody] MovieForm form)
        {
            var movie = await Mediator.Send(new UpdateMovieCommand(movieId, form));

            return Ok(movie);
        }

        [HttpDelete("{movieId}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteMovie([FromRoute] string movieId)
        {
            await Mediator.Send(new DeleteMovieCommand(movieId));

            return NoContent();
        }
    }
}
