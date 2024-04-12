using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.TransactionHeaders
{
    public class Details
    {
        public class Query : IRequest<Result<TransactionHeader>>
        {
            public Guid TransactionHeaderId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<TransactionHeader>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<TransactionHeader>> Handle(Query request, CancellationToken cancellationToken)
            {
                var transactionHeader = await _context.TransactionHeaders.FindAsync(request.TransactionHeaderId);

                return Result<TransactionHeader>.Success(transactionHeader);
            }
        }
    }
}