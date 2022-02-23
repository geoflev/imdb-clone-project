using imdb_clone_models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IMDBClone.Application.Features.Actors
{
    public record UpdateActorCommand(string ActorId, ActorForm form) : IRequest<ActorDto>;

    public class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommand, ActorDto>
    {
        public ImdbCloneDbContext Context { get; }
        public IMediator Mediator { get; }

        public UpdateActorCommandHandler(ImdbCloneDbContext context, IMediator mediator)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<ActorDto> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
        {
            /*if(await Context.Actors.AnyAsync(x => x.Id != Int32.Parse(request.ActorId) && x.LastName == request.form.LastName))
            {
                throw new ArgumentException("Actor doens't exist.");
            }*/

            var entity = await Context
                .Actors
                .FirstOrDefaultAsync(x => x.Id == request.ActorId)
                ?? throw new ArgumentException("Actor doens't exist.");

            entity = entity.FromDto(request.form);
            Context.Actors.Update(entity);
            await Context.SaveChangesAsync();

            return entity.ToDto();
        }
    }

}
