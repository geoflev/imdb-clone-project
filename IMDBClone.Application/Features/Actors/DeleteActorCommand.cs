using FluentValidation;
using imdb_clone_models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IMDBClone.Application.Features.Actors
{
    public record DeleteActorCommand(string ActorId) : IRequest;

    public class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand, Unit>
    {

        public ImdbCloneDbContext Context { get; }

        public DeleteActorCommandHandler(ImdbCloneDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<Unit> Handle(DeleteActorCommand request, CancellationToken cancellationToken)
        {
            var entity = await Context
                .Actors
                .FirstOrDefaultAsync(x => x.Id == request.ActorId)
                ?? throw new ArgumentException("Actor not found.");

            Context.Actors.Remove(entity);
            await Context.SaveChangesAsync();

            return Unit.Value;
        }
    }

    public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValidator()
        {
            RuleFor(x => x.ActorId).NotEmpty();
        }
    }
}
