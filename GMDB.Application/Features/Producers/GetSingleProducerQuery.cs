using GMDB.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GMDB.Application.Features.Producers
{
    public record GetSingleProducerQuery(string ProducerId) : IRequest<ProducerDto>;

    public class GetSingleProducerQueryHandler : IRequestHandler<GetSingleProducerQuery, ProducerDto>
    {
        public GMDBDbContext Context { get; }

        public GetSingleProducerQueryHandler(GMDBDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ProducerDto> Handle(GetSingleProducerQuery request, CancellationToken cancellationToken)
        {
            var entity = await Context
                .Producers
                .FirstOrDefaultAsync(x => x.Id == request.ProducerId)
                ?? throw new ArgumentException("Producer not found.");

            return entity.ToDto();
        }
    }
}
