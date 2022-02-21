using imdb_clone_models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IMDBClone.Application.Features.Movies
{
    public record DeleteMovieCommand(string MovieId) : IRequest;
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, Unit>
    {
        public ImdbCloneDbContext Context { get; }

        public DeleteMovieCommandHandler(ImdbCloneDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var entity = await Context
                .Movies
                .Include(x => x.Categories)
                .FirstOrDefaultAsync(x => x.Id == Int32.Parse(request.MovieId))
                ?? throw new ArgumentNullException("Movie was not found");

            Context.Movies.Remove(entity);
            await Context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
