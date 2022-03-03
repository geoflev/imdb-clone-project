using GMDB.Application.Features;
using GMDB.Application.Features.Producers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace GMDB.API.Controllers
{
    [Route("api/producers")]
    public class ProducersController : Controller
    {

        public IMediator Mediator { get; }

        public ProducersController(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{producerId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProducerDto))]
        public async Task<IActionResult> GetProducer([FromRoute] string producerId)
        {
            var producer = await Mediator.Send(new GetSingleProducerQuery(producerId));
            return Ok(producer);
        }

        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ProducerDto>))]
        public async Task<IActionResult> GetProducers()
        {
            var producers = await Mediator.Send(new GetProducersQuery());
            return Ok(producers);
        }

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProducerDto))]
        public async Task<IActionResult> CreateProducer([FromBody] ProducerForm form)
        {
            var producer = await Mediator.Send(new CreateProducerCommand(form));
            return Ok(producer);
        }

        [HttpPut("{producerId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProducerDto))]
        public async Task<IActionResult> UpdateProducer(
            [FromRoute] string producerId,
            [FromBody] ProducerForm form)
        {
            var producer = await Mediator.Send(new UpdateProducerCommand(producerId, form));
            return Ok(producer);
        }

        [HttpDelete("{producerId}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteProducer([FromRoute] string producerId)
        {
            await Mediator.Send(new DeleteProducerCommand(producerId));
            return NoContent();
        }
    }
}
