using GMDB.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GMDB.Application.Features.Actors
{
    public record GetActorsQuery() : IRequest<IEnumerable<ActorDto>>;

    class GetActorsQueryHandler : IRequestHandler<GetActorsQuery, IEnumerable<ActorDto>>
    {
        public GMDBDbContext Context { get; }

        public GetActorsQueryHandler(GMDBDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<ActorDto>> Handle(GetActorsQuery request, CancellationToken cancellationToken)
        {
            var entities = await Context
                .Actors
                .AsNoTracking()
                .ToListAsync();
            return entities.Select(x => x.ToDto());
        }
    }
}
