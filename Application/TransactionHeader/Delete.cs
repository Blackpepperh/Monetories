using Application.Core;
using MediatR;
using Persistence;

namespace Application.TransactionHeaders
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid TransactionHeaderId { get; set; }
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
                var transactionHeader = await _context.TransactionHeaders.FindAsync(request.TransactionHeaderId);

                if (transactionHeader == null) return null;

                _context.Remove(transactionHeader);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete the Transaction Header");

                return Result<Unit>.Success(Unit.Value);
            }
        }

    }
}