using imdb_clone_models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IMDBClone.Application.Features.Categories
{
    public record UpdateCategoryCommand(string categoryId, CategoryForm form) : IRequest<CategoryDto>;

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
    {
        public ImdbCloneDbContext Context;

        public UpdateCategoryCommandHandler(ImdbCloneDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await Context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == request.categoryId)
                ?? throw new ArgumentException("Category was not found!");

            category = category.FromDto(request.form);

            Context.Categories.Update(category);
            await Context.SaveChangesAsync(cancellationToken);

            return category.ToDto();
        }
    }
}
