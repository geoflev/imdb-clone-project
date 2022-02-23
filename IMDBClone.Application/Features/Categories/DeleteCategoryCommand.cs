using imdb_clone_models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IMDBClone.Application.Features.Categories
{
    public record DeleteCategoryCommand(string categortId) : IRequest;

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        public ImdbCloneDbContext Context { get; }

        public DeleteCategoryCommandHandler(ImdbCloneDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await Context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == request.categortId)
                ?? throw new ArgumentException("Category not found!");

            Context.Categories.Remove(entity);
            await Context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
