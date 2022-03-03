using GMDB.Persistence;
using GMDB.Persistence.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GMDB.Application.Features.Actors
{
    public record CreateActorCommand(ActorForm form) : IRequest<ActorDto>;

    public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, ActorDto>
    {
        public GMDBDbContext Context { get; }

        public IMediator Mediator { get; }

        public CreateActorCommandHandler(GMDBDbContext context, IMediator mediator)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<ActorDto> Handle(CreateActorCommand request, CancellationToken cancellationToken)
        {
            var actor = new ActorEntity().FromDto(request.form);
            await Context.Actors.AddAsync(actor);
            await Context.SaveChangesAsync();

            return actor.ToDto();
        }
    }

}
