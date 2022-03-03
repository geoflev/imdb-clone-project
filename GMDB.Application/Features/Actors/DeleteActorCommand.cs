using FluentValidation;
using GMDB.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GMDB.Application.Features.Actors
{
    public record DeleteActorCommand(string ActorId) : IRequest;

    public class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand, Unit>
    {

        public GMDBDbContext Context { get; }

        public DeleteActorCommandHandler(GMDBDbContext context)
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
