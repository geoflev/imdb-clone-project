using imdb_clone_models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IMDBClone.Application.Features.Categories
{
    public record GetSingleCategoryQuery(string categoryId) : IRequest<CategoryDto>;

    public class GetSingleCategoryQueryHandler : IRequestHandler<GetSingleCategoryQuery, CategoryDto>
    {
        public ImdbCloneDbContext Context;
        public GetSingleCategoryQueryHandler(ImdbCloneDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<CategoryDto> Handle(GetSingleCategoryQuery request, CancellationToken cancellationToken)
        {
            var entity = await Context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == request.categoryId)
                ?? throw new ArgumentException("Category not found!");

            return entity.ToDto();
        }
    }
}
