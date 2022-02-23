using imdb_clone_models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IMDBClone.Application.Features.Producers
{
    public record UpdateProducerCommand(string ProducerId, ProducerForm form) : IRequest<ProducerDto>;

    public class UpdateProducerCommandHandler : IRequestHandler<UpdateProducerCommand, ProducerDto>
    {
        public ImdbCloneDbContext Context { get; }
        public IMediator Mediator { get; }

        public UpdateProducerCommandHandler(ImdbCloneDbContext context, IMediator mediator)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<ProducerDto> Handle(UpdateProducerCommand request, CancellationToken cancellationToken)
        {
            var entity = await Context
                .Producers
                .FirstOrDefaultAsync(x => x.Id == request.ProducerId)
                ?? throw new ArgumentException("Producer doens't exist.");

            entity = entity.FromDto(request.form);
            Context.Producers.Update(entity);
            await Context.SaveChangesAsync(cancellationToken);

            return entity.ToDto();
        }
    }

}
