using IMDBClone.Application.Features;
using IMDBClone.Application.Features.Actors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IMDB_Clone_API.Controllers
{
    [Route("api/actors")]
    public class ActorsController : Controller
    {

        public IMediator Mediator { get; }

        public ActorsController(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ActorDto>))]
        public async Task<IActionResult> GetActors()
        {
            var actors = await Mediator.Send(new GetActorsQuery());
            return Ok(actors);
        }

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ActorDto>))]
        public async Task<IActionResult> CreateActor([FromBody] ActorForm form)
        {
            var actor = await Mediator.Send(new CreateActorCommand(form));
            return Ok(actor);
        }
    }
}
