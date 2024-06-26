using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Transactions
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
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
                var Transaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (Transaction == null) return null;

                _context.Remove(Transaction);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete the Transaction");

                return Result<Unit>.Success(Unit.Value);
            }
        }

    }
}