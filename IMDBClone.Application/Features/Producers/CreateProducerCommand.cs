using imdb_clone_models;
using imdb_clone_models.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IMDBClone.Application.Features.Producers
{
    public record CreateProducerCommand(ProducerForm form) : IRequest<ProducerDto>;

    public class CreateProducerCommandHandler : IRequestHandler<CreateProducerCommand, ProducerDto>
    {
        public ImdbCloneDbContext Context { get; }

        public IMediator Mediator { get; }

        public CreateProducerCommandHandler(ImdbCloneDbContext context, IMediator mediator)
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
