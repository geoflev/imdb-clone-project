using IMDBClone.Application.Features;
using IMDBClone.Application.Features.Actors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace IMDBClone.API.Controllers
{
    [Route("api/actors")]
    public class ActorsController : Controller
    {

        public IMediator Mediator { get; }

        public ActorsController(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{actorId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ActorDto))]
        public async Task<IActionResult> GetActor([FromRoute] string actorId)
        {
            var actor = await Mediator.Send(new GetSingleActorQuery(actorId));
            return Ok(actor);
        }

        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ActorDto>))]
        public async Task<IActionResult> GetActors()
        {
            var actors = await Mediator.Send(new GetActorsQuery());
            return Ok(actors);
        }

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ActorDto))]
        public async Task<IActionResult> CreateActor([FromBody] ActorForm form)
        {
            var actor = await Mediator.Send(new CreateActorCommand(form));
            return Ok(actor);
        }

        [HttpPut("{actorId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ActorDto))]
        public async Task<IActionResult> UpdateActor(
            [FromRoute] string actorId, 
            [FromBody] ActorForm form)
        {
            var actor = await Mediator.Send(new UpdateActorCommand(actorId, form));
            return Ok(actor);
        }

        [HttpDelete("{actorId}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteActor([FromRoute] string actorId)
        {
            await Mediator.Send(new DeleteActorCommand(actorId));
            return NoContent();
        }
    }
}
