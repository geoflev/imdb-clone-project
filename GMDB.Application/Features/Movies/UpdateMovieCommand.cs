using GMDB.Persistence;
using GMDB.Persistence.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GMDB.Application.Features.Movies
{
    public record UpdateMovieCommand(string MovieId, MovieForm Form) : IRequest<MovieDto>;
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, MovieDto>
    {
        public GMDBDbContext Context { get; }

        public UpdateMovieCommandHandler(GMDBDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<MovieDto> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var entity = await Context
                .Movies
                .FirstOrDefaultAsync(x => x.Id == request.MovieId)
                ?? throw new ArgumentException("Movie was not found!");

            entity = entity.FromDto(request.Form);

            var movieCategories = Context
                .MovieCategories
                .AsNoTracking()
                .Where(x => x.MovieId.ToString() == request.MovieId)
                .ToListAsync();

            foreach (MovieCategoriesEntity mc in await movieCategories)
            {
                Context.MovieCategories.Remove(mc);
            }

            Context.Movies.Update(entity);
            await Context.SaveChangesAsync(cancellationToken);

            return entity.ToDto();

        }
    }
}
