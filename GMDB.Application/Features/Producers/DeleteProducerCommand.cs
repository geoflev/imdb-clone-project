using FluentValidation;
using GMDB.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GMDB.Application.Features.Producers
{
    public record DeleteProducerCommand(string ProducerId) : IRequest;

    public class DeleteProducerCommandHandler : IRequestHandler<DeleteProducerCommand, Unit>
    {

        public GMDBDbContext Context { get; }

        public DeleteProducerCommandHandler(GMDBDbContext context)
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
