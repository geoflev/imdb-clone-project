using GMDB.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GMDB.Application.Features.Movies
{
    public record DeleteMovieCommand(string MovieId) : IRequest;
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, Unit>
    {
        public GMDBDbContext Context { get; }

        public DeleteMovieCommandHandler(GMDBDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var entity = await Context
                .Movies
                .Include(x => x.Categories)
                .FirstOrDefaultAsync(x => x.Id == request.MovieId)
                ?? throw new ArgumentNullException("Movie was not found");

            Context.Movies.Remove(entity);
            await Context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
