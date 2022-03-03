using GMDB.Persistence;
using GMDB.Persistence.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GMDB.Application.Features.Movies
{
    public record CreateMovieCommand(MovieForm Form) : IRequest<MovieDtoLite>;

    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, MovieDtoLite>
    {
        public GMDBDbContext Context { get; }
        public IMediator Mediator { get; }

        public CreateMovieCommandHandler(GMDBDbContext context, IMediator mediator)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<MovieDtoLite> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            foreach(var categoryId in request.Form.Categories)
            {
                if(!await Context.Categories.AnyAsync(x => x.Id == categoryId)){
                    throw new ArgumentException("Category doesn't exist");
                }
            }
            foreach (var actorId in request.Form.Actors)
            {
                if (!await Context.Actors.AnyAsync(x => x.Id == actorId))
                {
                    throw new ArgumentException("Actor doesn't exist");
                }
            }
            foreach (var producerId in request.Form.Producers)
            {
                if (!await Context.Producers.AnyAsync(x => x.Id == producerId))
                {
                    throw new ArgumentException("Producer doesn't exist");
                }
            }


            var movie = new MovieEntity().FromDto(request.Form);

            await Context.Movies.AddAsync(movie, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);

            return movie.ToDtoLite();
        }
    }

}
