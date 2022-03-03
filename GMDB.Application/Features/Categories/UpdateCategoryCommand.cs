using GMDB.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GMDB.Application.Features.Categories
{
    public record UpdateCategoryCommand(string categoryId, CategoryForm form) : IRequest<CategoryDto>;

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
    {
        public GMDBDbContext Context;

        public UpdateCategoryCommandHandler(GMDBDbContext context)
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
