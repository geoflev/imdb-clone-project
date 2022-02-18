using imdb_clone_models;
using imdb_clone_models.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IMDBClone.Application.Features.Actors
{
    public record CreateActorCommand(ActorForm form) : IRequest<ActorDto>;

    public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, ActorDto>
    {
        public ImdbCloneDbContext Context { get; }
    
        public IMediator Mediator { get; }

        public CreateActorCommandHandler(ImdbCloneDbContext context, IMediator mediator)
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
