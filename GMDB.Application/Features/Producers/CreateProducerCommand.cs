using GMDB.Persistence;
using GMDB.Persistence.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GMDB.Application.Features.Producers
{
    public record CreateProducerCommand(ProducerForm form) : IRequest<ProducerDto>;

    public class CreateProducerCommandHandler : IRequestHandler<CreateProducerCommand, ProducerDto>
    {
        public GMDBDbContext Context { get; }

        public IMediator Mediator { get; }

        public CreateProducerCommandHandler(GMDBDbContext context, IMediator mediator)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<ProducerDto> Handle(CreateProducerCommand request, CancellationToken cancellationToken)
        {
            var producer = new ProducerEntity().FromDto(request.form);
            await Context.Producers.AddAsync(producer);
            await Context.SaveChangesAsync();

            return producer.ToDto();
        }
    }

}
