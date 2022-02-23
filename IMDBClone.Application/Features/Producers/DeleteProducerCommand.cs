using FluentValidation;
using imdb_clone_models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IMDBClone.Application.Features.Producers
{
    public record DeleteProducerCommand(string ProducerId) : IRequest;

    public class DeleteProducerCommandHandler : IRequestHandler<DeleteProducerCommand, Unit>
    {

        public ImdbCloneDbContext Context { get; }

        public DeleteProducerCommandHandler(ImdbCloneDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<Unit> Handle(DeleteProducerCommand request, CancellationToken cancellationToken)
        {
            var entity = await Context
                .Producers
                .FirstOrDefaultAsync(x => x.Id == request.ProducerId)
                ?? throw new ArgumentException("Producer not found.");

            Context.Producers.Remove(entity);
            await Context.SaveChangesAsync();

            return Unit.Value;
        }
    }

    public class DeleteProducerCommandValidator : AbstractValidator<DeleteProducerCommand>
    {
        public DeleteProducerCommandValidator()
        {
            RuleFor(x => x.ProducerId).NotEmpty();
        }
    }
}
