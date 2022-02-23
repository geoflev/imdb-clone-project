using imdb_clone_models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IMDBClone.Application.Features.Producers
{
    public record GetSingleProducerQuery(string ProducerId) : IRequest<ProducerDto>;

    public class GetSingleProducerQueryHandler : IRequestHandler<GetSingleProducerQuery, ProducerDto>
    {
        public ImdbCloneDbContext Context { get; }

        public GetSingleProducerQueryHandler(ImdbCloneDbContext context)
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
