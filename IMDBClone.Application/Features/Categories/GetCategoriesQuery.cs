using imdb_clone_models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IMDBClone.Application.Features.Categories
{
    public record GetCategoriesQuery() : IRequest<IEnumerable<CategoryDto>>;

    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
    {
        public ImdbCloneDbContext Context { get; }

        public GetCategoriesQueryHandler(ImdbCloneDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var entities = await Context
                .Categories
                .AsNoTracking()
                .ToListAsync();
            return entities.Select(x => x.ToDto());
        }
    }
}
