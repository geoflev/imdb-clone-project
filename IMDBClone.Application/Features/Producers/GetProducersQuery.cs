using imdb_clone_models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IMDBClone.Application.Features.Producers
{
    public record GetProducersQuery() : IRequest<IEnumerable<ProducerDto>>;

    class GetProducersQueryHandler : IRequestHandler<GetProducersQuery, IEnumerable<ProducerDto>>
    {
        public ImdbCloneDbContext Context { get; }

        public GetProducersQueryHandler(ImdbCloneDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<ProducerDto>> Handle(GetProducersQuery request, CancellationToken cancellationToken)
        {
            var entities = await Context
                .Producers
                .AsNoTracking()
                .ToListAsync();
            return entities.Select(x => x.ToDto());
        }
    }
}
