using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.TransactionDetails
{
    public class Details
    {
        public class Query : IRequest<Result<TransactionDetail>>
        {
            public Guid TransactionDetailId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<TransactionDetail>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<TransactionDetail>> Handle(Query request, CancellationToken cancellationToken)
            {
                var transactionDetail = await _context.TransactionDetails.FindAsync(request.TransactionDetailId);

                return Result<TransactionDetail>.Success(transactionDetail);
            }
        }
    }
}