using GMDB.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GMDB.Application.Features.Actors
{
    public record GetSingleActorQuery(string ActorId) : IRequest<ActorDto>;

    public class GetSingleActorQueryHandler : IRequestHandler<GetSingleActorQuery, ActorDto>
    {
        public GMDBDbContext Context { get; }

        public GetSingleActorQueryHandler(GMDBDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ActorDto> Handle(GetSingleActorQuery request, CancellationToken cancellationToken)
        {
            var entity = await Context
                .Actors
                .FirstOrDefaultAsync(x => x.Id == request.ActorId)
                ?? throw new ArgumentException("Actor not found.");

            return entity.ToDto();
        }
    }
}
