using imdb_clone_models;
using IMDBClone.Persistence.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IMDBClone.Application.Features.Movies
{
    public record CreateMovieCommand(MovieForm Form) : IRequest<MovieDto>;

    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, MovieDto>
    {
        public ImdbCloneDbContext Context { get; }
        public IMediator Mediator { get; }

        public CreateMovieCommandHandler(ImdbCloneDbContext context, IMediator mediator)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<MovieDto> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {

            var movie = new MovieEntity().FromDto(request.Form);

            await Context.Movies.AddAsync(movie, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);

            return movie.ToDto();
        }
    }

}
