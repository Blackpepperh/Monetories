using Application.Core;
using MediatR;
using Persistence;

namespace Application.TransactionDetails
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid TransactionDetailId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var transactionDetail = await _context.TransactionDetails.FindAsync(request.TransactionDetailId);

                if (transactionDetail == null) return null;

                _context.Remove(transactionDetail);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete the Transaction Detail");

                return Result<Unit>.Success(Unit.Value);
            }
        }

    }
}