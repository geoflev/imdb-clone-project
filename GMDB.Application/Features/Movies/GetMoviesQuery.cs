using GMDB.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GMDB.Application.Features.Movies
{
    public record GetMoviesQuery() : IRequest<IEnumerable<MovieDto>>;


    class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IEnumerable<MovieDto>>
    {
        public GMDBDbContext Context { get; }

        public GetMoviesQueryHandler(GMDBDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<MovieDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            var entities = await Context
                .Movies
                .AsNoTracking()
                .Include(x => x.Categories)
                    .ThenInclude(x => x.Category)
                .Include(x => x.Actors)
                    .ThenInclude(x => x.Actor)
                .Include(x => x.Producers)
                    .ThenInclude(x => x.Producer)
                .ToListAsync();

            return entities.Select(x => x.ToDto());
        }
    }
}
