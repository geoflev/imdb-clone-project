using imdb_clone_models;
using IMDBClone.Persistence.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IMDBClone.Application.Features.Categories
{
    public record CreateCategoryCommand(CategoryForm form) : IRequest<CategoryDto>;

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        public ImdbCloneDbContext Context { get; }

        public CreateCategoryCommandHandler(ImdbCloneDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (await Context.Categories.AnyAsync(x => x.Name == request.form.Name))
            {
                throw new ArgumentException("Category already exists");
            }

            var category = new CategoryEntity().FromDto(request.form);
            await Context.Categories.AddAsync(category);
            await Context.SaveChangesAsync();

            return category.ToDto();
        }
    }

}
