using GMDB.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GMDB.Application.Features.Actors
{
    public record UpdateActorCommand(string ActorId, ActorForm form) : IRequest<ActorDto>;

    public class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommand, ActorDto>
    {
        public GMDBDbContext Context { get; }
        public IMediator Mediator { get; }

        public UpdateActorCommandHandler(GMDBDbContext context, IMediator mediator)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<ActorDto> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
        {
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
