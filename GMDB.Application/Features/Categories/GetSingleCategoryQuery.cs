using GMDB.Application.Features;
using GMDB.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GMDB.Application.Features.Categories
{
    public record GetSingleCategoryQuery(string categoryId) : IRequest<CategoryDto>;

    public class GetSingleCategoryQueryHandler : IRequestHandler<GetSingleCategoryQuery, CategoryDto>
    {
        public GMDBDbContext Context;
        public GetSingleCategoryQueryHandler(GMDBDbContext context)
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
