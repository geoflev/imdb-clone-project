using imdb_clone_models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IMDBClone.Application.Features.Movies
{
    public record GetMoviesQuery() : IRequest<IEnumerable<MovieDto>>;


    class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IEnumerable<MovieDto>>
    {
        public ImdbCloneDbContext Context { get; }

        public GetMoviesQueryHandler(ImdbCloneDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<MovieDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            var entities = await Context
                .Movies
                .AsNoTracking()
                .Include(x => x.Categories)
                .Include(x => x.Actors)
                .Include(x => x.Producers)
                .ToListAsync();

            return entities.Select(x => x.ToDto());
        }
    }
}
