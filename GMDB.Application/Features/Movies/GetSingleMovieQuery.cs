using GMDB.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GMDB.Application.Features.Movies
{
    public record GetSingleMovieQuery(string movieId) : IRequest<MovieDto>;
    public class GetSingleMovieQueryhandler : IRequestHandler<GetSingleMovieQuery, MovieDto>
    {
        public GMDBDbContext Context { get; }

        public GetSingleMovieQueryhandler(GMDBDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<MovieDto> Handle(GetSingleMovieQuery request, CancellationToken cancellationToken)
        {
            var entity = await Context
                .Movies
                .Include(x => x.Categories)
                .FirstOrDefaultAsync(x => x.Id == request.movieId)
                ?? throw new ArgumentException("Movie not found.");

            return entity.ToDto();
        }
    }
}
